using System;

namespace DotPlatform.Auditing
{
    /// <summary>
    /// 用户访问数据审计信息
    /// </summary>
    public class AuditInfo
    {
        /// <summary>
        /// 租户 Id
        /// </summary>
        public Guid? TenantId { get; set; }

        // Todo: use TenantName replace TenantId
        //public string TenantName { get; set; }

        /// <summary>
        /// 用户 Id
        /// </summary>
        public Guid? UserId { get; set; }

        // Todo: use UserName replace UserId
        //public string UserName { get; set; }

        /// <summary>
        /// Service (class/interface) name.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 请求的方法名称
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// 当前请求地址的跳转来源
        /// </summary>
        public string UrlReferrer { get; set; }

        /// <summary>
        /// 开始执行的时间
        /// </summary>
        public DateTime ExecutionTime { get; set; }

        /// <summary>
        /// 总共执行的时间（毫秒）
        /// </summary>
        public int ExecutionDuration { get; set; }

        /// <summary>
        /// 访问的客户端 IP
        /// </summary>
        public string ClientIpAddress { get; set; }

        /// <summary>
        /// 访问的客户端主机名
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 访问的客户端浏览器信息
        /// </summary>
        public string BrowserInfo { get; set; }

        /// <summary>
        /// Optional custom data that can be filled and used.
        /// </summary>
        public string CustomData { get; set; }

        /// <summary>
        /// 执行中出现的异常信息
        /// </summary>
        public Exception Exception { get; set; }
    }
}
