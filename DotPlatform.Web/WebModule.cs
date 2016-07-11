using DotPlatform.Auditing;
using DotPlatform.Dependency;
using DotPlatform.Modules;
using DotPlatform.Web.Auditing;

namespace DotPlatform.Web
{
    [DependsOn]
    public class WebModule : ModuleBase
    {
        public override void PreInitialize()
        {
            IocManager.Register<IAuditInfoProvider, WebAuditInfoProvider>(IocLifeStyle.Transient);


            IocManager.Build();
        }
    }
}
