using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace DotPlatform.Zero.Domain.Models.Core
{
    /// <summary>
    /// 基于 Zero 模块的角色
    /// </summary>
    public class Role : AggregateRoot, IMayHaveTenant, ISoftDelete, ICreationAudited
    {
        #region Properties

        /// <summary>
        /// 租户.为 null 表示不含有租户
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// 租户
        /// </summary>
        public virtual Tenant Tenant { get; private set; }

        /// <summary>
        /// 角色的唯一名
        /// </summary>
        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        [StringLength(256)]
        public string Description { get; set; }

        /// <summary>
        /// 获取一个<see cref="bool"/>值，表示角色是否已激活
        /// </summary>
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public Guid CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 角色所包含的用户集合
        /// </summary>
        public virtual List<User> Users { get; private set; }

        /// <summary>
        /// 角色拥有的权限集合
        /// </summary>
        public virtual List<Permission> Permissions { get; private set; }

        #endregion

        #region Ctor

        public Role()
        {
        }

        /// <summary>
        /// 初始化一个新的<see cref="Role"/>对象
        /// </summary>
        /// <param name="tenantId">角色所在的租户 Id， null 表示没有租户</param>
        /// <param name="name">唯一的角色名称</param>
        /// <param name="description">角色描述</param>
        public Role(Guid? tenantId, string name, string description)
        {
            TenantId = tenantId;
            Name = name;

            Activate();
        }

        /// <summary>
        /// 初始化一个新的<see cref="Role"/>对象
        /// </summary>
        /// <param name="name">唯一的角色名称</param>
        /// <param name="description">角色描述</param>
        public Role(string name, string description)
            : this(null, name, description)
        {
            
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
