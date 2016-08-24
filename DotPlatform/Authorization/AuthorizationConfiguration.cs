using DotPlatform.Collections;

namespace DotPlatform.Authorization
{
    /// <summary>
    /// 授权配置类
    /// </summary>
    internal class AuthorizationConfiguration : IAuthorizationConfiguration
    {
        public ITypeList<AuthorizationProvider> Providers { get; }

        public AuthorizationConfiguration()
        {
            Providers = new TypeList<AuthorizationProvider>();
        }
    }
}
