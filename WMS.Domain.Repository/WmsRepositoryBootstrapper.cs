using DotPlatform.Configuration;
using DotPlatform.Dependency;
using DotPlatform.EntityFramework;

namespace WMS.Domain.Repository
{
    /// <summary>
    /// WMS 项目引导程序
    /// </summary>
    internal class WmsRepositoryBootstrapper : IAppInitializer
    {
        public void Initialize()
        {
            IocManager.Instance.Register<WmsEfDbContext>(IocLifeStyle.Transient);
            IocManager.Instance.RegisterGeneric(typeof(IDbContextProvider<>), typeof(SimpleDbContextProvider<>));
        }
    }
}
