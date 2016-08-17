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
        public static string GetClientIp(HttpContext httpContext)
        {
            return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] 
                ?? HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        /// <summary>
        /// 获取客户的IP V4地址。
        /// 对于主机自身访问，可
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
        /// 获取客户端访问的主机名
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
