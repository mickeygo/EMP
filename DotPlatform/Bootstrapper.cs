using System;
using System.Collections.Generic;
using System.Reflection;
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
        private IIocManager _iocaManager;
        IModuleManager _moduleManager;

        protected bool IsDisposed;

        public Bootstrapper() : this(IocManager.Instance)
        {

        }

        public Bootstrapper(IIocManager iocManager)
        {
            _iocaManager = iocManager;
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

        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            _moduleManager.Shutdown();
        }
    }
}
