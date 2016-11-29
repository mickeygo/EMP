using DotPlatform.Dependency;
using DotPlatform.Logger.NLog;
using DotPlatform.Loggers;
using DotPlatform.Modules;

namespace DotPlatform.Logger
{
    [DependsOn]
    public class LoggerModule : ModuleBase
    {
        public override void PreInitialize()
        {
            IocManager.Register<ILogger, NLogger>(IocLifeStyle.Singleton);

            base.PreInitialize();
        }
    }
}
