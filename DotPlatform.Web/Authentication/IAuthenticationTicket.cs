using Microsoft.Owin.Security;

namespace DotPlatform.Web.Authentication
{
    /// <summary>
    /// 表示实现此接口的类为验证票据
    /// </summary>
    public interface IAuthenticationTicket
    {
        /// <summary>
        /// 创建登录的验证票据
        /// </summary>
        /// <param name="authenticationData">验证身份数据</param>
        /// <param name="ispersistent">是否持久化</param>
        /// <param name="authenticationType">验证类型</param>
        /// <returns><see cref="AuthenticationTicket"/>验证票据</returns>
        AuthenticationTicket CreateTicket(AuthenticationData authenticationData, bool IsPersistent, string authenticationType);
    }
}
