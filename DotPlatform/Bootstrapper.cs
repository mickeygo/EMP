using System;
using DotPlatform.Dependency.Installers;
using DotPlatform.Dependency;
using DotPlatform.Configuration.Startup.Impl;
using DotPlatform.Modules;

namespace DotPlatform
{
    /// <summary>
    /// 系统引导程序。在系统启动时执行，是进入系统的入口。
    /// </summary>
    public class Bootstrapper : IDisposable
    {
        private readonly IIocManager _iocaManager;
        IModuleManager _moduleManager;

        /// <summary>
        /// 是否已 Disposed.
        /// </summary>
        protected bool IsDisposed;

        /// <summary>
        /// 初始化一个新的<see cref="Bootstrapper"/>实例
        /// </summary>
        public Bootstrapper()
        {
            _iocaManager = IocManager.Instance;
        }

        /// <summary>
        /// 初始化程序。查询启动会执行该方法
        /// </summary>
        public virtual void Initialize()
        {
            // 安装组件
            KernelComponentInstaller.Instance.Install();

            // Configuration
            _iocaManager.Resolve<AppStartupConfiguration>().Initialize();

            // Module
            _moduleManager = _iocaManager.Resolve<IModuleManager>();
            _moduleManager.Initialize();
        }

        /// <summary>
        /// 加载所有的程序集
        /// </summary>
        public virtual void LoadAllAssemblies()
        {
            // Todo： 如何将 IAssemblyFinder 对象在此重写

        }

        /// <summary>
        /// Dispose
        /// </summary>
        public virtual void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            _moduleManager.Shutdown();
            IsDisposed = true;
        }
    }
}
