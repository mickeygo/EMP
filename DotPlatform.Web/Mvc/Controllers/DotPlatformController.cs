using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DotPlatform.Auditing;
using DotPlatform.Extensions;
using DotPlatform.Runtime.Session;
using DotPlatform.Serialization.Json;
using DotPlatform.Timing;
using DotPlatform.Web.Extensions;
using DotPlatform.Net.Mail;
using DotPlatform.Dependency;
using Newtonsoft.Json;

namespace DotPlatform.Web.Mvc.Controllers
{
    /// <summary>
    /// 基于 DotPlatform 平台的 Mvc 控制器基类
    /// </summary>
    public abstract class DotPlatformController : Controller
    {
        #region Private Fields

        private Stopwatch _actionStopwatch;

        private AuditInfo _auditInfo;

        private MethodInfo _currentMethodInfo;

        private static Type[] _ignoredTypesForSerialization = { typeof(HttpPostedFileBase) };

        #endregion

        #region Protected Properties

        /// <summary>
        /// 获取 Ioc 解析器
        /// </summary>
        protected IIocResolver IocResolver
        {
            get { return IocManager.Instance; }
        }

        /// <summary>
        /// 获取当前区域时间，根据区域的不同而设计的时间不同
        /// </summary>
        protected DateTime LocalDateTime
        {
            get { return Clock.Local; }
        }

        #endregion 

        #region Public Properties

        public IOwnerSession OwnerSession { get; set; }

        public IAuditInfoProvider AuditInfoProvider { get; set; }

        public IAuditingStore AuditingStore { get; set; }

        /// <summary>
        /// Email 对象，用于发送邮件
        /// </summary>
        public IMailSender MailSender
        {
            get { return IocResolver.Resolve<IMailSender>(); }
        }

        #endregion

        #region Public Methods


        #endregion

        #region Json

        /// <summary>
        /// Json 序列化，基于 Newtonsoft.Json 框架
        /// </summary>
        /// <param name="isSuccess">要传递的状态 status: success/fail</param>
        /// <param name="message">要传递的消息 message</param>
        /// <returns>Json</returns>
        public JsonResult Json(bool isSuccess, string message = null)
        {
            return Json(isSuccess, null, message, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Json 序列化，基于 Newtonsoft.Json 框架
        /// </summary>
        /// <param name="isSuccess">要传递的状态 status: success/fail</param>
        /// <param name="data">要序列化的数据 data</param>
        /// <param name="message">要传递的消息 message</param>
        /// <returns>Json</returns>
        public JsonResult Json(bool isSuccess, object data, string message = null)
        {
            return Json(isSuccess, data, message, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Json 序列化，基于 Newtonsoft.Json 框架
        /// </summary>
        /// <param name="isSuccess">要传递的状态 status: true/false</param>
        /// <param name="data">要序列化的数据 data</param>
        /// <param name="message">要传递的消息 message</param>
        /// <param name="behavior">请求 Json 序列化的行为</param>
        /// <returns>Json</returns>
        public JsonResult Json(bool isSuccess, object data, string message, JsonRequestBehavior behavior)
        {
            return JsonEx(new { status = isSuccess, data, message }, null, null, behavior, null);
        }

        /// <summary>
        /// Json 序列化，基于 Newtonsoft.Json 框架
        /// </summary>
        /// <param name="data">要序列化的数据</param>
        /// <returns></returns>
        protected JsonResult JsonEx(object data)
        {
            return JsonEx(data, null, null);
        }

        /// <summary>
        /// Json 序列化，基于 Newtonsoft.Json 框架
        /// </summary>
        /// <param name="data">要序列化的数据</param>
        /// <param name="contentType">输出的内容类型</param>
        /// <param name="contentEncoding">输出的内容编码</param>
        /// <returns></returns>
        protected JsonResult JsonEx(object data, string contentType, Encoding contentEncoding)
        {
            return JsonEx(data, contentType, contentEncoding, JsonRequestBehavior.AllowGet, null);
        }

        /// <summary>
        /// Json 序列化，基于 Newtonsoft.Json 框架
        /// </summary>
        /// <param name="data">要序列化的数据</param>
        /// <param name="contentType">输出的内容类型</param>
        /// <param name="contentEncoding">输出的内容编码</param>
        /// <param name="behavior">允许的 Json 请求行为</param>
        /// <param name="jsonSettings">json 参数, 见<see cref="JsonSerializerSettings"/></param>
        /// <returns></returns>
        protected JsonResult JsonEx(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior, JsonSerializerSettings jsonSettings)
        {
            var json = jsonSettings == null ? new JsonResultEx() : new JsonResultEx(jsonSettings);
            json.Data = data;
            json.ContentType = contentType;
            json.ContentEncoding = contentEncoding;
            json.JsonRequestBehavior = behavior;

            return json;
        }

        #endregion

        #region OnActionExecuting / OnActionExecuted

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        #endregion

        #region Exception handling

        protected override void OnException(ExceptionContext filterContext)
        {
            
        }

        #endregion

        #region Auditing

        private void HandleAuditingBeforeAction(ActionExecutingContext filterContext)
        {
            if (!ShouldSaveAudit(filterContext))
            {
                _auditInfo = null;
                return;
            }

            _actionStopwatch = Stopwatch.StartNew();
            _auditInfo = new AuditInfo
            {
                TenantId = OwnerSession.TenantId,
                UserId = OwnerSession.UserId,
                ServiceName = _currentMethodInfo.DeclaringType != null
                                ? _currentMethodInfo.DeclaringType.FullName
                                : filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                MethodName = _currentMethodInfo.Name,
                Parameters = ConvertArgumentsToJson(filterContext.ActionParameters),
                ExecutionTime = Clock.System
            };
        }

        private void HandleAuditingAfterAction(ActionExecutedContext filterContext)
        {
            if (_auditInfo == null || _actionStopwatch == null)
            {
                return;
            }

            _actionStopwatch.Stop();

            _auditInfo.ExecutionDuration = Convert.ToInt32(_actionStopwatch.Elapsed.TotalMilliseconds);
            _auditInfo.Exception = filterContext.Exception;

            if (AuditInfoProvider != null)
            {
                AuditInfoProvider.Fill(_auditInfo);
            }

            AuditingStore.SaveAsync(_auditInfo);
        }

        private bool ShouldSaveAudit(ActionExecutingContext filterContext)
        {
            //if (AuditingConfiguration == null)
            //{
            //    return false;
            //}

            //if (!AuditingConfiguration.MvcControllers.IsEnabled)
            //{
            //    return false;
            //}

            //if (filterContext.IsChildAction && !AuditingConfiguration.MvcControllers.IsEnabledForChildActions)
            //{
            //    return false;
            //}

            //return AuditingHelper.ShouldSaveAudit(
            //    _currentMethodInfo,
            //    AuditingConfiguration,
            //    AbpSession,
            //    true
            //    );

            return true;
        }

        private string ConvertArgumentsToJson(IDictionary<string, object> arguments)
        {
            try
            {
                if (arguments.IsNullOrEmpty())
                {
                    return "{}";
                }

                var dictionary = new Dictionary<string, object>();

                foreach (var argument in arguments)
                {
                    if (argument.Value != null && _ignoredTypesForSerialization.Any(t => t.IsInstanceOfType(argument.Value)))
                    {
                        dictionary[argument.Key] = null;
                    }
                    else
                    {
                        dictionary[argument.Key] = argument.Value;
                    }
                }

                return JsonSerializationHelper.Serialize(dictionary);
            }
            catch
            {
                return "{}";
            }
        }

        #endregion
    }
}
