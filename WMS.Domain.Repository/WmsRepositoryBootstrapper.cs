using DotPlatform.Configuration;
using DotPlatform.Dependency;
using WMS.Domain.Repositories;
using WMS.Domain.Repositories.Query;
using WMS.Domain.Repository.EntityFramework.QueryRepositories;
using WMS.Domain.Repository.EntityFramework.Repositories;

namespace WMS.Domain.Repository
{
    /// <summary>
    /// WMS 项目引导程序
    /// </summary>
    internal class WmsRepositoryBootstrapper : IApplicationInitializer
    {
        public void Initialize()
        {
            IocManager.Instance.Register<WmsEfDbContext>(IocLifeStyle.Transient);
            IocManager.Instance.Register<WmsReadEfDbContext>(IocLifeStyle.Transient);

            #region Repositry

            // Warehouse Repositry
            IocManager.Instance.Register<IWarehouseQueryRepository, WarehouseQueryRepository>();
            IocManager.Instance.Register<IWarehouseRepository, WarehouseRepository>();

            #endregion

            IocManager.Instance.Build();
        }
    }
}
