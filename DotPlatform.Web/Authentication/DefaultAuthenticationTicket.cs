using System.Security.Claims;
using Microsoft.Owin.Security;

namespace DotPlatform.Web.Authentication
{
    /// <summary>
    /// 默认的验证票据
    /// </summary>
    public class DefaultAuthenticationTicket : IAuthenticationTicket
    {
        public AuthenticationTicket Ticket { get; private set; }

        public DefaultAuthenticationTicket()
        {
            Ticket = new AuthenticationTicket(GetClaimsIdentity(), GetAuthenticationProperties());
        }

        #region Private Methods

        private AuthenticationProperties GetAuthenticationProperties()
        {
            return new AuthenticationProperties { };
        }

        private ClaimsIdentity GetClaimsIdentity()
        {
            var claimsIdentity = new ClaimsIdentity();


            return claimsIdentity;
        }

        #endregion
    }
}
