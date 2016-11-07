using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;

namespace DotPlatform.Zero.Domain.Models.Core
{
    /// <summary>
    /// 基于 Zero 模块的权限
    /// </summary>
    public class Permission : AggregateRoot, ISoftDelete
    {
        #region Properties

        /// <summary>
        /// 权限唯一名称
        /// </summary>
        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 权限显示名称
        /// </summary>
        [Required]
        [StringLength(128)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 权限描述
        /// </summary>
        [StringLength(256)]
        public string Description { get; set; }

        /// <summary>
        /// 获取一个<see cref="bool"/>值，表示角色是否已激活
        /// </summary>
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        /// <summary>
        /// 权限包含的角色集合
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }

        /// <summary>
        /// 权限包含的菜单集合
        /// </summary>
        public virtual ICollection<Menu> Menus { get; set; }
      
        #endregion

        #region Ctor



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
