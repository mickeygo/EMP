using DotPlatform.Configuration;
using DotPlatform.Dependency;
using WMS.Domain.QueryRepositories;
using WMS.Domain.Repositories;
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
            IocManager.Instance.Register<WmsEfDbContext>();
            IocManager.Instance.Register<WmsQueryEfDbContext>();

            #region Repositry

            // Warehouse Repository
            IocManager.Instance.Register<IWarehouseQueryRepository, WarehouseQueryRepository>();
            IocManager.Instance.Register<IWarehouseRepository, WarehouseRepository>();
            IocManager.Instance.Register<IZoneQueryRepository, ZoneQueryRepository>();
            IocManager.Instance.Register<IZoneRepository, ZoneRepository>();
            IocManager.Instance.Register<IShelfQueryRepository, ShelfQueryRepository>();
            IocManager.Instance.Register<IShelfRepository, ShelfRepository>();
            IocManager.Instance.Register<ILocationQueryRepository, LocationQueryRepository>();
            IocManager.Instance.Register<ILocationRepository, LocationRepository>();

            // StockIn Repository
            IocManager.Instance.Register<IStockInRepository, StockInRepository>();
            IocManager.Instance.Register<IStockInQueryRepository, StockInQueryRepository>();

            #endregion

            IocManager.Instance.Build();
        }
    }
}
