using System;
using DotPlatform.Domain.Entities;
using DotPlatform.RBAC.Domain.Models.Roles;

namespace DotPlatform.RBAC.Domain.Models.Users
{
    /// <summary>
    /// 用户组与角色关联关系（多对多）
    /// </summary>
    public class UserGroupInRole : AggregateRoot
    {
        /// <summary>
        /// 获取用户组 Id
        /// </summary>
        public Guid UserGroupId { get; }

        /// <summary>
        /// 获取用户组
        /// </summary>
        public virtual RbacUserGroup UserGroup { get; }

        /// <summary>
        /// 获取角色 Id
        /// </summary>
        public Guid RoleId { get; }

        /// <summary>
        /// 获取角色
        /// </summary>
        public virtual RbacRole Role { get; }

        /// <summary>
        /// 初始化一个新的<see cref="UserGroupInRole"/>实例
        /// </summary>
        /// <param name="userGroupId">用户组 Id</param>
        /// <param name="roleId">角色 Id</param>
        public UserGroupInRole(Guid userGroupId, Guid roleId)
        {
            UserGroupId = userGroupId;
            RoleId = roleId;
        }
    }
}
