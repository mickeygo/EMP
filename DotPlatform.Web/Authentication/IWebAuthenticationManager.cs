using System;

namespace DotPlatform.Web.Authentication
{
    /// <summary>
    /// 验证管理类
    /// </summary>
    public interface IWebAuthenticationManager
    {
        /// <summary>
        /// 登录
        /// </summary>
        void SignIn(Func<AuthenticationData> action);

        /// <summary>
        /// 登出
        /// </summary>
        void SignOut();
    }
}
