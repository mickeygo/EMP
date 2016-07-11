using Microsoft.Owin.Security;

namespace DotPlatform.Web.Authentication
{
    /// <summary>
    /// 验证类提供者
    /// </summary>
    public interface IAuthenticationProvider
    {
        /// <summary>
        /// 提供者
        /// </summary>
        IAuthenticationManager Provider { get; }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="authenticationTicket">验证票据</param>
        void SignIn(AuthenticationTicket authenticationTicket);

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="options">验证属性</param>
        /// <param name="authenticationTypes">验证类型</param>
        void SignOut(AuthenticationProperties options, string[] authenticationTypes);
    }
}
