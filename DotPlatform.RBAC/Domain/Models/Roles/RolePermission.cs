using System;
using DotPlatform.Domain.Entities;
using DotPlatform.RBAC.Domain.Permissions;

namespace DotPlatform.RBAC.Domain.Models.Roles
{
    /// <summary>
    /// 角色权限关系(多对多)
    /// </summary>
    public class RolePermission : AggregateRoot
    {
        /// <summary>
        /// 获取角色 Id
        /// </summary>
        public Guid RoleId { get; }

        /// <summary>
        /// 获取角色
        /// </summary>
        public virtual RbacRole Role { get; }

        /// <summary>
        /// 获取权限 Id
        /// </summary>
        public Guid PermissionId { get; }

        /// <summary>
        /// 获取权限
        /// </summary>
        public virtual RbacPermission Permission { get; }

        /// <summary>
        /// 初始化一个新的<see cref="RolePermission"/>实例
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="permissionId"></param>
        public RolePermission(Guid roleId, Guid permissionId)
        {
            RoleId = roleId;
            PermissionId = permissionId;
        }
    }
}
