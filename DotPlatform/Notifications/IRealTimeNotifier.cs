using System.Threading.Tasks;

namespace DotPlatform.Notifications
{
    /// <summary>
    /// 即使通信通知者
    /// </summary>
    public interface IRealTimeNotifier
    {
        /// <summary>
        /// 发送通知信息到指定的用户。
        /// 若用户不在线，应该忽略该用户。
        /// </summary>
        /// <param name="userNotifications">用户通知集合</param>
        /// <returns></returns>
        Task SendNotificationsAsync(UserNotification[] userNotifications);
    }
}
