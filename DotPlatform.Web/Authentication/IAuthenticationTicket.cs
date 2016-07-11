using Microsoft.Owin.Security;

namespace DotPlatform.Web.Authentication
{
    /// <summary>
    /// 表示实现此接口的类为验证票据
    /// </summary>
    public interface IAuthenticationTicket
    {
        /// <summary>
        /// 获取验证票据
        /// </summary>
        AuthenticationTicket Ticket { get; }
    }
}
