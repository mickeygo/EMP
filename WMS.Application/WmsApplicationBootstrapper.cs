using DotPlatform.Configuration;
using DotPlatform.Dependency;
using WMS.Application.ImplServices;
using WMS.Application.Services;

namespace WMS.Application
{
    /// <summary>
    /// Wms 应用服务启动配置项
    /// </summary>
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
