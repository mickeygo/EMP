using DotPlatform.Collections;

namespace DotPlatform.Authorization
{
    /// <summary>
    /// 表示实现此接口的类为权限配置类
    /// </summary>
    public interface IAuthorizationConfiguration
    {
        /// <summary>
        /// 获取授权提供者
        /// </summary>
        ITypeList<AuthorizationProvider> Providers { get; }
    }
}
