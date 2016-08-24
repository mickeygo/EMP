using DotPlatform.Collections.Extensions;

namespace DotPlatform.Authorization
{
    /// <summary>
    /// 表示权限定义上下文基类
    /// </summary>
    internal abstract class PermissionDefinitionContextBase : IPermissionDefinitionContext
    {
        /// <summary>
        /// 权限字典集合。用于存储权限
        /// </summary>
        protected readonly PermissionDictionary Permissions;

        protected PermissionDefinitionContextBase()
        {
            Permissions = new PermissionDictionary();
        }

        public Permission CreatePermission(string name, string displayName = null, bool isGrantedByDefault = false, string description = null)
        {
            if (Permissions.ContainsKey(name))
            {
                throw new DotPlatformException("There is already a permission with name: " + name);
            }

            var permission = new Permission(name, displayName, isGrantedByDefault, description);
            Permissions[permission.Name] = permission;
            return permission;
        }

        public Permission GetPermissionOrNull(string name)
        {
            return Permissions.GetOrDefault(name);
        }
    }
}
