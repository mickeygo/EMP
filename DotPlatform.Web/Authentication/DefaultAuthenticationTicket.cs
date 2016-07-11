using System.Security.Claims;
using Microsoft.Owin.Security;

namespace DotPlatform.Web.Authentication
{
    /// <summary>
    /// 默认的验证票据
    /// </summary>
    public class DefaultAuthenticationTicket : IAuthenticationTicket
    {
        public AuthenticationTicket CreateTicket(AuthenticationData authenticationData, bool IsPersistent)
        {
            var claimsIdentity = GetClaimsIdentity(authenticationData);
            var properties = new AuthenticationProperties { IsPersistent = IsPersistent };
            return new AuthenticationTicket(claimsIdentity, properties);
        }

        #region Private Methods

        private ClaimsIdentity GetClaimsIdentity(AuthenticationData data)
        {
            return AuthenticationHelper.CreateClaimsIdentity(data);
        }

        #endregion
    }
}
