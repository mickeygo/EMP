using System;
using DotPlatform.Dependency.Installers;
using DotPlatform.Dependency;
using DotPlatform.Modules;
using DotPlatform.Configuration;
using DotPlatform.Configuration.Startup;

namespace DotPlatform
{
    /// <summary>
    /// 系统引导程序。在系统启动时执行，是进入系统的入口。
    /// </summary>
    public class Bootstrapper : IBootstrapper
    {
        private IModuleManager _moduleManager;
        private readonly IIocManager _iocManager;

        private static object sync = new object();

        /// <summary>
        /// 是否已 Disposed.
        /// </summary>
        protected bool IsDisposed;

        /// <summary>
        /// 应用程序在初始化前处理事件
        /// </summary>
        public event EventHandler PreInitializeEvent;

        /// <summary>
        /// 应用程序已初始化后处理事件
        /// </summary>
        public event EventHandler PostInitializeEvent;

        /// <summary>
        /// 初始化一个新的<see cref="Bootstrapper"/>实例
        /// </summary>
        public Bootstrapper()
        {
            _iocManager = IocManager.Instance;
        }

        #region Public Methods

        /// <summary>
        /// Ioc 注册器
        /// </summary>
        public IIocRegistrar IocRegistrar
        {
            get { return _iocManager; }
        }

        /// <summary>
        /// 启动应用程序配置
        /// </summary>
        public void Start()
        {
            Init();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public virtual void Dispose()
        {
            if (IsDisposed)
                return;

            _moduleManager.Shutdown();
            IsDisposed = true;
        }

        #endregion

        #region Private Methods

        private void Init()
        {
            PreInitializeEvent?.Invoke(this, null);

            lock (sync)
            {
                // note: exec by follow order.
                // 安装组件
                KernelComponentInstaller.Instance.Install();

                // Configuration
                _iocManager.Resolve<IStartupConfiguration>().Initialize();

                // Module
                _moduleManager = _iocManager.Resolve<IModuleManager>();
                _moduleManager.Initialize();

                // Ioc 依赖对象注册
                _iocManager.Resolve<DependencyRegisterInstaller>().Install();

                // 实现了 IApplicationInitializer 接口的对象初始化
                _iocManager.Resolve<ApplicationInitializerManager>().Init();
            }

            PostInitializeEvent?.Invoke(this, null);
        }

        #endregion
    }
}
