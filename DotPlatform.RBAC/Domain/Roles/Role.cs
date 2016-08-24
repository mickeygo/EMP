using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace DotPlatform.RBAC.Domain.Roles
{
    /// <summary>
    /// 权限管理，权限信息
    /// </summary>
    public class Role : AggregateRoot, ISoftDelete, ICreationAudited
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
        /// 获取或设置权限是否已激活
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 表示权限是否已被删除
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

        public Role()
        {
        }

        /// <summary>
        /// 初始化一个新的<see cref="Role"/>对象
        /// </summary>
        /// <param name="name">唯一的角色名称</param>
        /// <param name="displayName">角色的显示名</param>
        /// <param name="description">角色描述</param>
        public Role(string name, string displayName, string description)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;

            Activate();
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
