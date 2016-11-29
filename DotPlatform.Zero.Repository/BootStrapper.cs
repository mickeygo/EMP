using DotPlatform.Configuration;
using DotPlatform.Dependency;
using DotPlatform.Zero.Repository.EntityFramework;
using DotPlatform.Zero.Domain.Repositories;
using DotPlatform.Zero.Repository.EntityFramework.Repositories;

namespace DotPlatform.Zero.Repository
{
    internal class BootStrapper : IApplicationInitializer
    {
        public void Initialize()
        {
            IocManager.Instance.Register<ZeroDbContext>();

            // Repository
            IocManager.Instance.Register<ITenantRepository, TenantRepository>();
            IocManager.Instance.Register<IUserRepository, UserRepository>();
            IocManager.Instance.Register<IRoleRepository, RoleRepository>();
            IocManager.Instance.Register<IUserRoleRepository, UserRoleRepository>();
            IocManager.Instance.Register<IPermissionRepository, PermissionRepository>();
            IocManager.Instance.Register<IRolePermissionRepository, RolePermissionRepository>();
            //IocManager.Instance.RegisterGeneric(typeof(IMenuRepository<>), typeof(MenuRepository<>));

            IocManager.Instance.Build();
        }
    }
}
