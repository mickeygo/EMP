using DotPlatform.Configuration;
using DotPlatform.Dependency;
using DotPlatform.Zero.Domain.Services;
using DotPlatform.Zero.Domain.Services.Impl;

namespace DotPlatform.Zero
{
    internal class BootStrapper : IApplicationInitializer
    {
        public void Initialize()
        {
            // Domain Service
            IocManager.Instance.Register<IUserDomainService, UserDomainService>();

            IocManager.Instance.Build();
        }
    }
}
