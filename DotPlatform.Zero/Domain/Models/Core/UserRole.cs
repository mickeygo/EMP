using System;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace DotPlatform.Zero.Domain.Models.Core
{
    /// <summary>
    /// 用户角色关联实体
    /// </summary>
    public class UserRole : AggregateRoot, ICreationAudited
    {
        /// <summary>
        /// 用户 Id
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// 用户
        /// </summary>
        public virtual User User { get; private set; }

        /// <summary>
        /// 角色 Id
        /// </summary>
        public Guid RoleId { get; private set; }

        /// <summary>
        /// 角色
        /// </summary>
        public virtual Role Role { get; private set; }

        public Guid CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }

        public UserRole()
        {
        }

        /// <summary>
        /// 初始化一个新的<see cref="UserRole"/>实例
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <param name="roleId">角色 Id</param>
        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
