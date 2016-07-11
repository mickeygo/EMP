using System.Web;
using Microsoft.Owin.Security;

namespace DotPlatform.Web.Authentication
{
    /// <summary>
    /// 基于 OWIN 的验证类提供者
    /// </summary>
    public class OwinAuthenticationProvider : IAuthenticationProvider
    {
        public IAuthenticationManager Provider
        {
            get { return GetAuthentication(); }
        }

        public void SignIn(AuthenticationTicket authenticationTicket)
        {
            this.Provider.SignIn(authenticationTicket.Properties, authenticationTicket.Identity);
        }

        public void SignOut(AuthenticationProperties options, string[] authenticationTypes)
        {
            this.Provider.SignOut(options, authenticationTypes);
        }

        #region Private Methods

        private IAuthenticationManager GetAuthentication()
        {
            var owinContext = HttpContext.Current.GetOwinContext();
            return owinContext.Authentication;
        }

        #endregion
    }
}
