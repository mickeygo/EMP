using Microsoft.AspNet.SignalR;
using Owin;

namespace DotPlatform.Web.SignalR
{
    /// <summary>
    /// SignalR 方法扩展类
    /// </summary>
    public static class SignalRExtensions
    {
        /// <summary>
        /// Maps SignalR hubs to the app builder pileline at "/signalr"
        /// </summary>
        /// <param name="app">IAppBuilder</param>
        public static void UseSignalR(this IAppBuilder app)
        {
            app.MapSignalR();
        }

        /// <summary>
        /// Maps SignalR hubs to the app builder pileline at "/signalr"
        /// </summary>
        /// <param name="app">IAppBuilder</param>
        /// <param name="configuartion">Hub 配置</param>
        public static void UseSignalR(this IAppBuilder app, HubConfiguration configuartion)
        {
            app.MapSignalR(configuartion);
        }
    }
}
