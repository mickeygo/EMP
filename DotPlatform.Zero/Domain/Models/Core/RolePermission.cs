using System;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace DotPlatform.Zero.Domain.Models.Core
{
    /// <summary>
    /// 角色权限关联实体
    /// </summary>
    public class RolePermission : AggregateRoot, ICreationAudited
    {
        /// <summary>
        /// 用户 Id
        /// </summary>
        public Guid RoleId { get; private set; }

        /// <summary>
        /// 角色
        /// </summary>
        public virtual Role Role { get; private set; }

        /// <summary>
        /// 角色 Id
        /// </summary>
        public Guid PermissionId { get; private set; }

        /// <summary>
        /// 权限
        /// </summary>
        public virtual Permission Permission { get; private set; }

        public Guid CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }

        public RolePermission()
        {

        }

        /// <summary>
        /// 初始化一个新的<see cref="RolePermission"/>实例
        /// </summary>
        /// <param name="roleId">角色 Id</param>
        /// <param name="permissionId">权限 Id</param>
        public RolePermission(Guid roleId, Guid permissionId)
        {
            RoleId = roleId;
            PermissionId = permissionId;
        }
    }
}
