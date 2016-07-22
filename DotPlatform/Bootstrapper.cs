using System;
using DotPlatform.Dependency.Installers;
using DotPlatform.Dependency;
using DotPlatform.Configuration.Startup.Impl;
using DotPlatform.Modules;
using DotPlatform.Configuration;

namespace DotPlatform
{
    /// <summary>
    /// 系统引导程序。在系统启动时执行，是进入系统的入口。
    /// </summary>
    public class Bootstrapper : IDisposable
    {
        private IModuleManager _moduleManager;
        private readonly IIocManager _iocManager;

        private static object sync = new object();

        /// <summary>
        /// 是否已 Disposed.
        /// </summary>
        protected bool IsDisposed;

        /// <summary>
        /// 初始化一个新的<see cref="Bootstrapper"/>实例
        /// </summary>
        public Bootstrapper()
        {
            _iocManager = IocManager.Instance;
        }

        /// <summary>
        /// 初始化之前处理
        /// </summary>
        public virtual void OnPreInitialize()
        {

        }

        /// <summary>
        /// 初始化程序。查询启动会执行该方法
        /// </summary>
        public virtual void OnInitialize()
        {
            lock (sync)
            {
                // 安装组件
                KernelComponentInstaller.Instance.Install();

                // Configuration
                _iocManager.Resolve<AppStartupConfiguration>().Initialize();

                // Module
                _moduleManager = _iocManager.Resolve<IModuleManager>();
                _moduleManager.Initialize();
            }
        }

        /// <summary>
        /// 初始化后事件处理
        /// </summary>
        public virtual void OnPostInitialize()
        {
            var initManger = _iocManager.Resolve<ApplicationInitializerManager>();
            initManger.Init();
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
