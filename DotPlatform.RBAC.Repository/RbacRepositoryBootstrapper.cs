using DotPlatform.Configuration;
using DotPlatform.Dependency;

namespace DotPlatform.RBAC.Repository
{
    /// <summary>
    /// RBAC 项目引导程序
    /// </summary>
    internal class RbacRepositoryBootstrapper : IApplicationInitializer
    {
        public void Initialize()
        {
            IocManager.Instance.Register<RbacEfDbContext>(IocLifeStyle.Transient);

            // Repository

            // Services

            //

            IocManager.Instance.Build();
        }
    }
}
