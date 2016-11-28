using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using DotPlatform.Notifications;
using DotPlatform.RealTime;
using DotPlatform.Web.SignalR.Hubs;
using DotPlatform.Loggers;

namespace DotPlatform.Web.SignalR.Notifications
{
    /// <summary>
    /// 
    /// </summary>
    public class SignalRRealTimeNotifier : IRealTimeNotifier
    {
        private readonly IOnlineClientManager _onlineClientManager;

        /// <summary>
        /// 初始化一个新的<see cref="IOnlineClientManager"/>实例
        /// </summary>
        /// <param name="onlineClientManager">在线客户端管理者</param>
        public SignalRRealTimeNotifier(IOnlineClientManager onlineClientManager)
        {
            _onlineClientManager = onlineClientManager;
        }

        public Task SendNotificationsAsync(UserNotification[] userNotifications)
        {
            foreach (var userNotification in userNotifications)
            {
                try
                {
                    // User is not online. No problem, go to the next user.
                    var onlineClient = _onlineClientManager.GetByUserIdOrNull(userNotification.UserId);
                    if (onlineClient == null)
                        continue;


                    var signalRClient = CommonHub.Clients.Client(onlineClient.ConnectionId);
                    if (signalRClient == null)
                    {
                        LoggerFactory.Logger.Debug("Can not get user " + userNotification.UserId + " from SignalR hub!");
                        continue;
                    }

                    // TODO: await call or not?
                    signalRClient.getNotification(userNotification);
                }
                catch (Exception ex)
                {
                    LoggerFactory.Logger.Warn("Could not send notification to userId: " + userNotification.UserId);
                    LoggerFactory.Logger.Warn(ex.ToString(), ex);
                }
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
