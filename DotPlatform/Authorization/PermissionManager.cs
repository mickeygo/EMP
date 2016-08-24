using System.Linq;
using System.Collections.Generic;
using DotPlatform.Collections.Extensions;
using DotPlatform.Dependency;

namespace DotPlatform.Authorization
{
    /// <summary>
    /// 权限管理类。用于创建和获取相应的权限
    /// </summary>
    internal class PermissionManager : PermissionDefinitionContextBase, IPermissionManager
    {
        private readonly IAuthorizationConfiguration _authorizationConfiguration;
        private static readonly object _lock = new object();

        public PermissionManager(IAuthorizationConfiguration authorizationConfiguration)
        {
            _authorizationConfiguration = authorizationConfiguration;
        }

        public IEnumerable<Permission> GetAllPermissions()
        {
            return Permissions.Values.ToList();
        }

        public Permission GetPermission(string name)
        {
            var permission = Permissions.GetOrDefault(name);
            if (permission == null)
                throw new DotPlatformException($"There is no permission with name: {name}");

            return permission;
        }

        public void Initialize()
        {
            foreach (var providerType in _authorizationConfiguration.Providers)
            {
                var provider = (AuthorizationProvider)IocManager.Instance.Resolve(providerType);
                provider.SetPermissions(this);
            }

            Permissions.AddPremissions();
        }

        #region Public Methods

        public void ReLoad()
        {
            lock (_lock)
            {
                Permissions.Clear();

                Initialize();
            }
        }

        #endregion
    }
}
