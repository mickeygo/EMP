namespace DotPlatform.Authorization
{
    /// <summary>
    /// 权限提供者基类.用于定义应用程序的权限
    /// </summary>
    public abstract class AuthorizationProvider
    {
        public abstract void SetPermissions(IPermissionDefinitionContext context);
    }
}
