using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using DotPlatform.Notifications;
using DotPlatform.Web.SignalR.Hubs;
using DotPlatform.RealTime;
using DotPlatform.Dependency;

namespace DotPlatform.Web.SignalR
{
    /// <summary>
    /// SignalR RealTime 扩展类
    /// </summary>
    public static class RealTimeExtensions
    {
        /// <summary>
        /// 广播消息。将消息发送给所有的连线者
        /// </summary>
        /// <param name="notifier"></param>
        /// <param name="messageNotification">通知消息</param>
        /// <returns></returns>
        public static Task BroadcastAsync(this IRealTimeNotifier notifier, MessageNotification messageNotification)
        {
            var signalRClient = CommonHub.Clients.All;
            signalRClient.getNotification(messageNotification);

            return Task.FromResult(0);
        }

        /// <summary>
        /// 广播消息。将消息发送给指定租户中所有的连线者
        /// </summary>
        /// <param name="notifier"></param>
        /// <param name="tenantId">要发给的租户 Id</param>
        /// <param name="messageNotification">通知消息</param>
        /// <returns></returns>
        public static Task BroadcastAsync(this IRealTimeNotifier notifier, Guid tenantId, MessageNotification messageNotification)
        {
            var onlineClientManager = IocManager.Instance.Resolve<IOnlineClientManager>();
            var clients = onlineClientManager.GetAllClients()
                            .Where(client => client.TenantId == tenantId)
                            .Select(c => c.ConnectionId).ToList();

            if (clients.Any())
            {
                var signalRClient = CommonHub.Clients.Clients(clients);
                signalRClient.getNotification(messageNotification);
            }

            return Task.FromResult(0);
        }

        private static IHubContext CommonHub
        {
            get
            {
                return GlobalHost.ConnectionManager.GetHubContext<DotPlatformCommonHub>();
            }
        }
    }
}
