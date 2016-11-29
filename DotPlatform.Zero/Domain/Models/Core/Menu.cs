using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace DotPlatform.Zero.Domain.Models.Core
{
    /// <summary>
    /// 基于 Zero 模块的菜单
    /// </summary>
    public class Menu : AggregateRoot, ISoftDelete, ICreationAudited
    {
        #region Properties

        /// <summary>
        /// 菜单的唯一名
        /// </summary>
        [Required]
        [StringLength(32)]
        public string Name { get; }

        /// <summary>
        /// 菜单描述
        /// </summary>
        [StringLength(256)]
        public string Description { get; private set; }

        /// <summary>
        /// 菜单图标（字体样式），可设置为 null.
        /// </summary>
        [StringLength(32)]
        public string Icon { get; set; }

        /// <summary>
        /// 菜单 Url， 为 null 表示菜单根目录或菜单子项的目录
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// 菜单排序.
        /// 菜单根目录排序或菜单子项内部排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 父菜单 Id
        /// </summary>
        public Guid? ParentId { get; private set; }

        /// <summary>
        /// 获取一个<see cref="bool"/>值，表示菜单是否已激活
        /// </summary>
        public bool IsActive { get; private set; }

        public bool IsDeleted { get; set; }

        public Guid CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 菜单隶属的权限集合
        /// </summary>
        public virtual List<Permission> Permissions { get; set; }

        #endregion

        #region Ctor

        public Menu()
        {

        }

        /// <summary>
        /// 初始化一个新的<see cref="Menu"/>实例
        /// </summary>
        /// <param name="name">菜单名</param>
        /// <param name="description">菜单描述</param>
        /// <param name="icon">菜单图标</param>
        /// <param name="url">菜单 Url</param>
        /// <param name="sort">菜单排序</param>
        /// <param name="parentId">父菜单的 Id</param>
        public Menu(string name, string description, string icon, string url, int sort, Guid? parentId = null)
        {
            Name = name;
            Description = description;
            Icon = icon;
            Url = url;
            Sort = sort;
            ParentId = parentId;

            Activate();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 将菜单附加到权限
        /// </summary>
        /// <param name="permission">要附加的权限实例</param>
        public void AttachToPermission(Permission permission)
        {
            if (Permissions == null)
                Permissions = new List<Permission>();

            Permissions.Add(permission);
        }

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
