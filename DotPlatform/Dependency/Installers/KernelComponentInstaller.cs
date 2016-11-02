using DotPlatform.Bus;
using DotPlatform.Configuration;
using DotPlatform.Configuration.Startup;
using DotPlatform.Configuration.Startup.Impl;
using DotPlatform.Domain.Uow;
using DotPlatform.Events;
using DotPlatform.Events.Bus;
using DotPlatform.Events.Startup;
using DotPlatform.Events.Storage;
using DotPlatform.Localization;
using DotPlatform.Modules;
using DotPlatform.Net.Mail;
using DotPlatform.Net.Mail.Smtp;
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
            // Interceptor
            _iocManager.Register<UnitOfWorkInterceptor>();

            // Reflection
            _iocManager.Register<ITypeFinder, TypeFinder>();

            // Module
            _iocManager.Register<IModuleFinder, DefaultModuleFinder>();
            _iocManager.Register<IModuleManager, ModuleManager>();

            // Timing
            _iocManager.Register<IClockProvider, LocalClockProvider>();

            // Localization
            _iocManager.Register<ILanguageProvider, DefaultLanguageProvider>();
            _iocManager.Register<ILanguageManager, LanguageManager>();

            // Net
            // Net - Mail
            _iocManager.Register<IMailSender, SmtpMailSender>(IocLifeStyle.Singleton);

            // Configuration
            _iocManager.Register<AppStartupConfiguration>();
            _iocManager.Register<IStartupConfiguration, AppStartupConfiguration>();
            _iocManager.Register<ISmtpMailSenderConfiguration, SmtpMailSenderConfiguration>(IocLifeStyle.Singleton);  // mail

            // InitializerManager
            _iocManager.Register<ApplicationInitializerManager>();

            // Uow
            _iocManager.Register<IUnitOfWorkDefaultOptions, UnitOfWorkDefaultOptions>();
            _iocManager.Register<IUnitOfWorkManager, UnitOfWorkManager>();
            _iocManager.Register<ICurrentUnitOfWorkProvider, CallContextCurrentUnitOfWorkProvider>();

            // Event & Bus
            _iocManager.Register<IEventHandlerFinder, EventHandlerFinder>();
            _iocManager.Register<IEventAggregator, EventAggregator>(IocLifeStyle.Singleton);
            _iocManager.Register<IDomainEventStorage, NullDomainEventStorage>(IocLifeStyle.Singleton); // Todo: Change the event storage
            
            _iocManager.Register<IEventBusProvider, EventBusProvider>();
            _iocManager.Register<IEventBus, EventBus>();
            _iocManager.Register<IBus, DirectBus>();

            // Build
            _iocManager.Build();
        }
    }
}
