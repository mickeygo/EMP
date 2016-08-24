using System;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace DotPlatform.Web.Authentication
{
    /// <summary>
    /// 默认的验证票据
    /// </summary>
    public class DefaultAuthenticationTicket : IAuthenticationTicket
    {
        private readonly DateTimeOffset expiresUtc = DateTimeOffset.UtcNow.AddDays(1);

        public AuthenticationTicket CreateTicket(AuthenticationData authenticationData, bool IsPersistent)
        {
            var claimsIdentity = CreateClaimsIdentity(authenticationData);
            var properties = new AuthenticationProperties
            {
                IsPersistent = IsPersistent,
                ExpiresUtc = expiresUtc
            };

            return new AuthenticationTicket(claimsIdentity, properties);
        }

        #region Private Methods

        private ClaimsIdentity CreateClaimsIdentity(AuthenticationData data)
        {
            return AuthenticationHelper.CreateClaimsIdentity(data);
        }

        #endregion
    }
}
