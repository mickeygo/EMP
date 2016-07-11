using DotPlatform.Auditing;
using DotPlatform.Dependency;
using DotPlatform.Modules;
using DotPlatform.Web.Auditing;
using DotPlatform.Web.Authentication;

namespace DotPlatform.Web
{
    [DependsOn]
    public class WebModule : ModuleBase
    {
        public override void PreInitialize()
        {
            IocManager.Register<IAuditInfoProvider, WebAuditInfoProvider>(IocLifeStyle.Transient);

            IocManager.Register<IAuthenticationTicket, DefaultAuthenticationTicket>();
            IocManager.Register<IAuthenticationProvider, OwinAuthenticationProvider>();
            IocManager.Register<IWebAuthenticationManager, CookieAuthenticationManager>();

            IocManager.Build();
        }
    }
}
