using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace DotPlatform.Web.Utility
{
    /// <summary>
    /// Web 辅助类
    /// </summary>
    public static class WebHelper
    {
        /// <summary>
        /// 获取客户端 IP
        /// </summary>
        public static string GetClientIp()
        {
            return GetClientIp(HttpContext.Current);
        }

        /// <summary>
        /// 获取客户端 IP
        /// </summary>
        /// <param name="httpContext">HttpContext 上下文</param>
        /// <returns></returns>
        public static string GetClientIp(HttpContext httpContext)
        {
            var httpRequest = httpContext.Request;
            var localIp = "127.0.0.1";
            if (httpRequest.IsLocal)
                return localIp;

            var ip = httpRequest.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? httpRequest.ServerVariables["REMOTE_ADDR"];

            return string.IsNullOrEmpty(ip) ? localIp : ip;
        }

        /// <summary>
        /// 获取客户的IP V4地址。
        /// </summary>
        public static string GetClientIpAddress(HttpContext httpContext)
        {
            var clientIp = GetClientIp(httpContext);

            var hostAddress = Dns.GetHostAddresses(clientIp)
                .FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);

            if (hostAddress != null)
                return hostAddress.ToString();

            // Host
            hostAddress = Dns.GetHostAddresses(Dns.GetHostName())
               .FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);
            return hostAddress?.ToString();
        }

        /// <summary>
        /// 获取客户端访问的主机名。
        /// 不出在时返回 null
        /// </summary>
        public static string GetClientHostName(HttpContext httpContext)
        {
            try
            {
                var clientIp = GetClientIp(httpContext);
                return Dns.GetHostEntry(IPAddress.Parse(clientIp)).HostName;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取当前请求地址的跳转来源
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static string GetUrlReferrer(HttpContext httpContext)
        {
            return httpContext.Request.UrlReferrer?.ToString();
        }
    }
}
