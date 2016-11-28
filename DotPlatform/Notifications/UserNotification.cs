using System;
using DotPlatform.Domain.Entities;

namespace DotPlatform.Notifications
{
    /// <summary>
    /// 用户通知信息
    /// </summary>
    public class UserNotification : Entity
    {
        /// <summary>
        /// 用户 Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 当前用户通知的状态
        /// </summary>
        public UserNotificationState State { get; set; }

        /// <summary>
        /// 通知内容
        /// </summary>
        public Notification Notification { get; set; }
    }
}
