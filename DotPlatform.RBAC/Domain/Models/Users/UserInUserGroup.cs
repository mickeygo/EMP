using System;
using DotPlatform.Domain.Entities;

namespace DotPlatform.RBAC.Domain.Models.Users
{
    /// <summary>
    /// 用户与用户组关联关系（多对多）
    /// </summary>
    public class UserInUserGroup : AggregateRoot
    {
        /// <summary>
        /// 获取用户 Id
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// 获取用户
        /// </summary>
        public virtual RbacUser User { get; }

        /// <summary>
        /// 获取用户组 Id
        /// </summary>
        public Guid UserGroupId { get; }

        /// <summary>
        /// 获取用户组
        /// </summary>
        public virtual RbacUserGroup UserGroup { get; }

        /// <summary>
        /// 初始化一个新的<see cref="UserInUserGroup"/>实例
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <param name="userGroupId">用户组 Id</param>
        public UserInUserGroup(Guid userId, Guid userGroupId)
        {
            UserId = userId;
            UserGroupId = userGroupId;
        }
    }
}
