using System;
using DotPlatform.Timing;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace DotPlatform.Notifications
{
    /// <summary>
    /// 通知信息
    /// </summary>
    [Serializable]
    public class Notification : Entity, IHasCreationTime
    {
        /// <summary>
        /// 通知的唯一名称
        /// </summary>
        public string NotificationName { get; set; }

        /// <summary>
        /// 通知的数据
        /// </summary>
        public NotificationData Data { get; set; }

        /// <summary>
        /// 当前实体的类型
        /// </summary>
        public Type EntityType { get; set; }

        /// <summary>
        /// 实体类型 (包含命名空间).
        /// </summary>
        public string EntityTypeName { get; set; }

        /// <summary>
        /// 实体 Id
        /// </summary>
        public object EntityId { get; set; }

        /// <summary>
        /// 通知等级
        /// </summary>
        public NotificationSeverity Severity { get; set; }

        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 初始化一个新的<see cref="Notification"/>实例
        /// </summary>
        public Notification()
        {
            CreationTime = Clock.System;
        }
    }
}
