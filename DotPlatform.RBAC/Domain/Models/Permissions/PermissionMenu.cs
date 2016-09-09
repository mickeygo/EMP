using System;
using DotPlatform.Domain.Entities;
using DotPlatform.RBAC.Domain.Models.Menus;
using DotPlatform.Authorization;

namespace DotPlatform.RBAC.Domain.Models.Permissions
{
    /// <summary>
    /// 权限与菜单关系
    /// </summary>
    public class PermissionMenu : AggregateRoot
    {
        /// <summary>
        /// 获取权限 Id
        /// </summary>
        public Guid PermissionId { get; }

        /// <summary>
        /// 获取权限
        /// </summary>
        public virtual Permission Permission { get; }

        /// <summary>
        /// 获取菜单 Id
        /// </summary>
        public Guid MenuId { get; }

        /// <summary>
        /// 获取菜单
        /// </summary>
        public virtual RbacMenu Menu { get; }

        /// <summary>
        /// 初始化一个新的<see cref="PermissionMenu"/>实例
        /// </summary>
        /// <param name="permissionId">权限 Id</param>
        /// <param name="menuId">菜单 Id</param>
        public PermissionMenu(Guid permissionId, Guid menuId)
        {
            PermissionId = permissionId;
            MenuId = menuId;
        }
    }
}
