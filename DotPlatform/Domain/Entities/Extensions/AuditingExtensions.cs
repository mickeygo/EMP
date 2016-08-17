using DotPlatform.Domain.Entities.Auditing;
using DotPlatform.Runtime.Session;
using DotPlatform.Timing;

namespace DotPlatform.Domain.Entities.Extensions
{
    /// <summary>
    /// 实体审计信息扩展
    /// </summary>
    public static class AuditingExtensions
    {
        /// <summary>
        /// 设置实体创建人信息
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="session">会话信息</param>
        public static void SeCreationAuditProperty(this ICreationAudited entity, IOwnerSession session)
        {
            if (session.UserId.HasValue)
                entity.CreatorUserId = session.UserId.Value;
        }

        /// <summary>
        /// 设置实体创建时间
        /// </summary>
        /// <param name="entity">实体</param>
        public static void SetCreationTimeAuditProperty(this IHasCreationTime entity)
        {
            entity.CreationTime = Clock.System;
        }

        /// <summary>
        /// 设置实体修改人信息
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="session">会话信息</param>
        public static void SetModificationAuditProperty(this IModificationAudited entity, IOwnerSession session)
        {
            if (session.UserId.HasValue)
                entity.LastModifierUserId = session.UserId;
        }

        /// <summary>
        /// 设置实体修改时间
        /// </summary>
        /// <param name="entity">实体</param>
        public static void SetModificationTimeAuditProperty(this IHasModificationTime entity)
        {
            entity.LastModificationTime = Clock.System;
        }

        /// <summary>
        /// 设置实体删除人信息
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="session">会话信息</param>
        public static void SetDeletionAuditProperty(this IDeletionAudited entity, IOwnerSession session)
        {
            if (session.UserId.HasValue)
                entity.DeleterUserId = session.UserId;
        }

        /// <summary>
        /// 设置实体删除时间
        /// </summary>
        /// <param name="entity">实体</param>
        public static void SetDeletionTimeAuditProperty(this IHasDeletionTime entity)
        {
            entity.DeletionTime = Clock.System;
        }
    }
}
