using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace DotPlatform.RBAC.Domain.Permissions
{
    /// <summary>
    /// RBAC 权限设计，权限信息
    /// </summary>
    public class RbacPermission : AggregateRoot, ISoftDelete, ICreationAudited
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
        /// 获取一个<see cref="bool"/>值，表示权限是否可用
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// 获取或设置一个<see cref="bool"/>值，表示权限是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 获取或设置创建人 Id
        /// </summary>
        public Guid CreatorUserId { get; set; }

        /// <summary>
        /// 获取或设置创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        #endregion

        #region Ctor

        public RbacPermission()
        {
        }

        /// <summary>
        /// 初始化一个新的<see cref="RbacPermission"/>实例
        /// </summary>
        /// <param name="name">权限唯一名</param>
        /// <param name="displayName">权限显示名称</param>
        /// <param name="description">权限描述</param>
        public RbacPermission(string name, string displayName, string description)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;

            Activate();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 激活权限
        /// </summary>
        public void Activate()
        {
            IsActive = true;
        }

        /// <summary>
        /// 禁用权限
        /// </summary>
        public void Inactivate()
        {
            IsActive = false;
        }

        #endregion
    }
}
