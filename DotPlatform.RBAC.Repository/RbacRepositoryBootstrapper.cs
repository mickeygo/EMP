using DotPlatform.Configuration;
using DotPlatform.Dependency;
using DotPlatform.RBAC.Domain.Repositories;
using DotPlatform.RBAC.Repository.EntityFramework.Repositories;

namespace DotPlatform.RBAC.Repository
{
    /// <summary>
    /// RBAC 项目引导程序
    /// </summary>
    internal class RbacRepositoryBootstrapper : IApplicationInitializer
    {
        public void Initialize()
        {
            IocManager.Instance.Register<RbacEfDbContext>();

            // Repository
            IocManager.Instance.Register<IUserRepository, UserRepository>();

            // Services

            //

            IocManager.Instance.Build();
        }
    }
}
