using Microsoft.AspNet.Identity;

namespace DotPlatform.Web.Authentication
{
    /// <summary>
    /// 基于 Cookie 的验证管理类
    /// </summary>
    public class CookieAuthenticationManager : IWebAuthenticationManager
    {
        /// <summary>
        /// 验证类型
        /// </summary>
        public const string AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;

        private readonly IAuthenticationProvider _authenticationProvider;
        private readonly IAuthenticationTicket _authenticationTicket;

        public CookieAuthenticationManager(IAuthenticationProvider authenticationProvider, IAuthenticationTicket ticket)
        {
            this._authenticationProvider = authenticationProvider;
            this._authenticationTicket = ticket;
        }

        public void SignIn(AuthenticationData data, bool ispersistent)
        {
            var ticket = _authenticationTicket.CreateTicket(data, ispersistent);
            this._authenticationProvider.SignIn(ticket);
        }

        public void SignOut()
        {
            _authenticationProvider.SignOut(null, new[] { AuthenticationType });
        }
    }
}
