using DotPlatform.Configuration;
using DotPlatform.Dependency;

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
        }
    }
}
