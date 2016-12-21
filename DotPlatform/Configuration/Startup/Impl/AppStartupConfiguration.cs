using DotPlatform.Dependency;
using DotPlatform.Net.Mail.Smtp;
using DotPlatform.Runtime.Caching.Configurations;

namespace DotPlatform.Configuration.Startup.Impl
{
    /// <summary>
    /// 应用程序启动配置类
    /// </summary>
    public class AppStartupConfiguration : IStartupConfiguration
    {
        private readonly IIocManager _iocManager;

        public AppStartupConfiguration()
        {
            _iocManager = IocManager.Instance;
        }

        public void Initialize()
        {
            RegisterConfiguration();
            HandleConfiguration();
        }

        private void RegisterConfiguration()
        {
            _iocManager.Register<ISmtpMailSenderConfiguration, SmtpMailSenderConfiguration>(IocLifeStyle.Singleton);  // mail
            _iocManager.Register<ICacheConfiguration, CacheConfiguration>(IocLifeStyle.Singleton);  // Cache

            _iocManager.Build();
        }

        private void HandleConfiguration()
        {
            var cacheConfiguration = _iocManager.Resolve<ICacheConfiguration>();
            
        }
    }
}
