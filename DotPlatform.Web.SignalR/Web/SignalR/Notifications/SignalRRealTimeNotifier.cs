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
    /// SignalR 即时通讯
    /// </summary>
    public class SignalRRealTimeNotifier : IRealTimeNotifier
    {
        private readonly IOnlineClientManager _onlineClientManager;
        private readonly ILogger _logger;

        /// <summary>
        /// 初始化一个新的<see cref="IOnlineClientManager"/>实例
        /// </summary>
        /// <param name="onlineClientManager">在线客户端管理者</param>
        public SignalRRealTimeNotifier(IOnlineClientManager onlineClientManager)
        {
            _onlineClientManager = onlineClientManager;

            _logger = LoggerFactory.Logger;
        }

        /// <summary>
        /// 发送通知给指定的在线用户。
        /// 这里只将信息发送给指定的在线用户。
        /// </summary>
        /// <param name="userNotifications">用户通知信息集合</param>
        /// <returns></returns>
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
                        _logger.Debug("Can not get user " + userNotification.UserId + " from SignalR hub!");
                        continue;
                    }

                    // TODO: await call or not?
                    signalRClient.getNotification(userNotification);  // "getNotification" to client proxy call
                }
                catch (Exception ex)
                {
                    _logger.Warn("Could not send notification to userId: " + userNotification.UserId);
                    _logger.Warn(ex.ToString(), ex);
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
