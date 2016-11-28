using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace DotPlatform.Web.SignalR.Hubs
{
    /// <summary>
    /// Common Hub
    /// </summary>
    public class DotPlatformCommonHub : Hub
    {
        /// <summary>
        /// 重写 OnConnected，连接到<see cref="Microsoft.AspNet.SignalR.Hubs.IHub"/>后回调
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnected()
        {
            await base.OnConnected();
            // Do somethings when your client connect to IHub.
        }

        /// <summary>
        /// 重写 OnDisconnected，从 <see cref="Microsoft.AspNet.SignalR.Hubs.IHub"/> 断开连接后回调
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override async Task OnDisconnected(bool stopCalled)
        {
            await base.OnDisconnected(stopCalled);
            // Do somethings when your client disconnect to IHub.
        }
    }
}
