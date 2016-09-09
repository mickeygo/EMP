using System;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace DotPlatform.Web.Extensions
{
    /// <summary>
    /// JsonResu 的扩展
    /// </summary>
    public class JsonResultEx : JsonResult
    {
        private readonly JsonSerializerSettings _jsonSettings;

        /// <summary>
        /// 初始化一个新的<see cref="JsonResultEx"/>实例
        /// </summary>
        public JsonResultEx()
        {
            _jsonSettings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd"
            };
        }

        /// <summary>
        /// 初始化一个新的<see cref="JsonResultEx"/>实例
        /// </summary>
        /// <param name="jsonSettings">Json 序列化设置</param>
        public JsonResultEx(JsonSerializerSettings jsonSettings)
        {
            _jsonSettings = jsonSettings;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if ((this.JsonRequestBehavior == JsonRequestBehavior.DenyGet) 
                && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("The Json Request not allowed GET Http Method.");
            }

            var response = context.HttpContext.Response;
             response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            if (this.ContentEncoding != null)
                response.ContentEncoding = this.ContentEncoding;

            if (this.Data != null)
            {
                if (this.RecursionLimit.HasValue)
                    _jsonSettings.MaxDepth = this.RecursionLimit.Value;

                // 忽略循环引用
                _jsonSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                response.Write(JsonConvert.SerializeObject(this.Data, _jsonSettings));
            }
        }
    }
}
