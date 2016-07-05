using System.Web;
using DotPlatform.Auditing;
using DotPlatform.Web.Utility;

namespace DotPlatform.Web.Auditing
{
    /// <summary>
    /// 基于 Web 应用程序的审计信息提供者. 实现 <see cref="IAuditInfoProvider"/> 接口
    /// </summary>
    public class WebAuditInfoProvider : IAuditInfoProvider
    {
        private readonly HttpContext _httpContext;

        public WebAuditInfoProvider()
        {
            _httpContext = HttpContext.Current;
        }

        public void Fill(AuditInfo auditInfo)
        {
            if (_httpContext == null)
            {
                return;
            }

            try
            {
                auditInfo.UrlReferrer = WebHelper.GetUrlReferrer(_httpContext);
                auditInfo.BrowserInfo = GetBrowserInfo(_httpContext);
                auditInfo.ClientIpAddress = WebHelper.GetClientIpAddress(_httpContext);
                auditInfo.ClientName = WebHelper.GetUrlReferrer(_httpContext);
            }
            catch
            {

            }
        }

        #region Private Methods

        private static string GetBrowserInfo(HttpContext httpContext)
        {
            return httpContext.Request.Browser.Browser + " / " +
                   httpContext.Request.Browser.Version + " / " +
                   httpContext.Request.Browser.Platform;
        }

        #endregion
    }
}
