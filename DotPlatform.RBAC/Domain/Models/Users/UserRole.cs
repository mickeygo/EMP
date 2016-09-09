using System;
using DotPlatform.Domain.Entities;
using DotPlatform.RBAC.Domain.Models.Roles;

namespace DotPlatform.RBAC.Domain.Models.Users
{
    /// <summary>
    /// 用户角色对应关系（多对多）
    /// </summary>
    public class UserRole : AggregateRoot
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
        /// 获取角色 Id
        /// </summary>
        public Guid RoleId { get; }

        /// <summary>
        /// 获取权限
        /// </summary>
        public virtual RbacRole Role { get; }

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
