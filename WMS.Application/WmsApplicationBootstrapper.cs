using DotPlatform.Configuration;
using DotPlatform.Dependency;
using WMS.Application.Services;
using WMS.Application.Services.Impl;

namespace WMS.Application
{
    internal class WmsApplicationBootstrapper : IApplicationInitializer
    {
        public void Initialize()
        {
             #region Applications

            // Warehouse
            IocManager.Instance.Register<IWarehouseAppService, WarehouseAppService>();

            #endregion

            IocManager.Instance.Build();
        }
    }
}
