using DotPlatform.Configuration.Startup;
using DotPlatform.Configuration.Startup.Impl;
using DotPlatform.Modules;
using DotPlatform.Reflection;
using DotPlatform.Timing;

namespace DotPlatform.Dependency.Installers
{
    /// <summary>
    /// 应用程序核心组件安装类
    /// </summary>
    internal class KernelComponentInstaller : IComponentInstaller
    {
        private readonly static KernelComponentInstaller _instance = new KernelComponentInstaller();
        private readonly IIocManager _iocManager;

        /// <summary>
        /// 获取<see cref="IComponentInstaller"/>实例
        /// </summary>
        public static IComponentInstaller Instance
        {
            get { return _instance; }
        }

        private KernelComponentInstaller()
        {
            _iocManager = IocManager.Instance;
        }

        public void Install()
        {
            _iocManager.Register<ITypeFinder, TypeFinder>();
            _iocManager.Register<IModuleFinder, DefaultModuleFinder>();
            _iocManager.Register<IModuleManager, ModuleManager>();
            _iocManager.Register<IClockProvider, LocalClockProvider>();

            _iocManager.Register<IStartupConfiguration, AppStartupConfiguration>();

            // Build
            _iocManager.Build();
        }
    }
}
