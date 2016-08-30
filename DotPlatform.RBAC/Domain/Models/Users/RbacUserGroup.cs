using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace DotPlatform.RBAC.Domain.Models.Users
{
    /// <summary>
    /// RBAC 权限管理，用户组信息
    /// </summary>
    public class RbacUserGroup : AggregateRoot, ICreationAudited
    {
        #region Properties

        /// <summary>
        /// 获取或设置唯一的用户组名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置用户组的显示名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 获取或设置用户组描述
        /// </summary>
        [StringLength(80)]
        public string Description { get; set; }

        /// <summary>
        /// 获取一个<see cref="bool"/>值，表示用户组是否已激活
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 获取或设置一个<see cref="bool"/>值，表示用户组是否已被删除
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

        public RbacUserGroup()
        {
        }

        /// <summary>
        /// 初始化一个新的<see cref="RbacUserGroup"/>实例
        /// </summary>
        /// <param name="name">唯一的用户组名</param>
        /// <param name="displayName">用户组显示名</param>
        /// <param name="description">用户组描述</param>
        public RbacUserGroup(string name, string displayName, string description)
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
