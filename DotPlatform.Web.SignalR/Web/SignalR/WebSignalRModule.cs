using DotPlatform.Modules;
using DotPlatform.Notifications;
using DotPlatform.Web.SignalR.Notifications;

namespace DotPlatform.Web.SignalR.Web.SignalR
{
    [DependsOn]
    internal class WebSignalRModule : ModuleBase
    {
        public override void PreInitialize()
        {
            IocManager.Register<IRealTimeNotifier, SignalRRealTimeNotifier>();

            base.PreInitialize();
        }
    }
}
