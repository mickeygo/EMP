using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;
using DotPlatform.RBAC.Domain.Models.Tenants;

namespace DotPlatform.RBAC.Domain.Models.Roles
{
    /// <summary>
    /// RBAC 权限管理，权限信息
    /// </summary>
    public class RbacRole : AggregateRoot, ISoftDelete, ICreationAudited
    {
        #region Properties

        /// <summary>
        /// 获取或设置权限的唯一名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置权限的显示名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 获取或设置权限描述
        /// </summary>
        [StringLength(80)]
        public string Description { get; set; }

        /// <summary>
        /// 获取租户.为 null 表示不含有租户
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// 获取租户信息
        /// </summary>
        public virtual RbacTenant Tenant { get; private set; }

        /// <summary>
        /// 获取一个<see cref="bool"/>值，表示权限是否已激活
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 获取或设置一个<see cref="bool"/>值，表示权限是否已被删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 获取或设置创建人
        /// </summary>
        public Guid CreatorUserId { get; set; }

        /// <summary>
        /// 获取或设置创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        #endregion

        #region Ctor

        public RbacRole()
        {
        }

        /// <summary>
        /// 初始化一个新的<see cref="RbacRole"/>对象
        /// </summary>
        /// <param name="tenantId">角色所在的租户 Id， null 表示没有租户</param>
        /// <param name="name">唯一的角色名称</param>
        /// <param name="displayName">角色的显示名</param>
        public RbacRole(Guid? tenantId, string name, string displayName)
        {
            TenantId = tenantId;
            Name = name;
            DisplayName = displayName;

            Activate();
        }

        /// <summary>
        /// 初始化一个新的<see cref="RbacRole"/>对象
        /// </summary>
        /// <param name="name">唯一的角色名称</param>
        /// <param name="displayName">角色的显示名</param>
        /// <param name="description">角色描述</param>
        public RbacRole(string name, string displayName, string description)
            : this((Guid?)null, name, displayName)
        {
            Description = description;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 激活角色
        /// </summary>
        public void Activate()
        {
            IsActive = true;
        }

        /// <summary>
        /// 禁用角色
        /// </summary>
        public void Inactivate()
        {
            IsActive = false;
        }

        #endregion
    }
}
