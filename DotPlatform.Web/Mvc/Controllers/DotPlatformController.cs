using DotPlatform.Auditing;
using DotPlatform.Extensions;
using DotPlatform.Runtime.Session;
using DotPlatform.Serialization;
using DotPlatform.Timing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

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

        #region Public Properties

        public IOwnerSession OwnerSession { get; set; }

        public IAuditInfoProvider AuditInfoProvider { get; set; }

        public IAuditingStore AuditingStore { get; set; }

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
