using System;
using Microsoft.AspNet.Identity;

namespace DotPlatform.Web.Authentication
{
    /// <summary>
    /// 基于 Cookie 的验证管理类
    /// </summary>
    public class CookieAuthenticationManager : IWebAuthenticationManager
    {
        public const string AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;
        private readonly IAuthenticationProvider _authenticationProvider;
        private readonly IAuthenticationTicket _authenticationTicket;

        public CookieAuthenticationManager(IAuthenticationProvider authenticationProvider, IAuthenticationTicket ticket)
        {
            this._authenticationProvider = authenticationProvider;
            this._authenticationTicket = ticket;
        }

        public void SignIn(Func<AuthenticationData> action)
        {
            this._authenticationProvider.SignIn(_authenticationTicket.Ticket);
        }

        public void SignOut()
        {
            _authenticationProvider.SignOut(_authenticationTicket.Ticket.Properties, new[] { AuthenticationType });
        }
    }
}
