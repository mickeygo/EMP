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
        /// <param name="data">验证身份数据</param>
        /// <param name="ispersistent">是否持久化</param>
        void SignIn(AuthenticationData data, bool ispersistent);

        /// <summary>
        /// 登出
        /// </summary>
        void SignOut();
    }
}
