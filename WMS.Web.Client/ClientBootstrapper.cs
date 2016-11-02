using DotPlatform.Configuration;
using DotPlatform.Dependency;
using WMS.Web.Client.External.Ez;

namespace WMS.Web.Client
{
    /// <summary>
    /// Client 初始化时启动项
    /// </summary>
    internal class ClientBootstrapper : IApplicationInitializer
    {
        public void Initialize()
        {
            IocManager.Instance.Register<EzUserRepository>();

            IocManager.Instance.Build();
        }
    }
}
