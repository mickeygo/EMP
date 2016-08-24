using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace DotPlatform.RBAC.Domain.Menus
{
    /// <summary>
    /// 菜单信息
    /// </summary>
    public class Menu : AggregateRoot, ISoftDelete, ICreationAudited, IModificationAudited
    {
        #region Properties

        /// <summary>
        /// 获取菜单的唯一名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; }

        /// <summary>
        /// 获取菜单的显示名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string DisplayName { get; private set; }

        /// <summary>
        /// 获取或设置菜单描述
        /// </summary>
        [StringLength(80)]
        public string Description { get; private set; }

        /// <summary>
        /// 获取菜单 Url
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// 获取菜单的父菜单 Id
        /// </summary>
        public Guid? ParentId { get; private set; }

        /// <summary>
        /// 获取菜单是否已激活
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// 获取或设置菜单是否已删除
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

        /// <summary>
        /// 获取或设置最后修改人 Id
        /// </summary>
        public Guid? LastModifierUserId { get; set; }

        /// <summary>
        /// 获取或设置最后修改时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }

        #endregion

        #region Ctor

        public Menu()
        {
        }

        /// <summary>
        /// 初始化一个新的<see cref="Menu"/>实例
        /// </summary>
        /// <param name="name">菜单唯一名</param>
        /// <param name="displayName">菜单显示名</param>
        /// <param name="description">菜单描述</param>
        /// <param name="url">菜单地址</param>
        /// <param name="parentId">父菜单</param>
        public Menu(string name, string displayName, string description, string url, Guid? parentId = null)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
            Url = url;
            ParentId = parentId;

            Activate();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="displayName">菜单显示名</param>
        /// <param name="description">菜单描述</param>
        /// <param name="url">菜单 Url</param>
        public void Update(string displayName, string description, string url)
        {
            DisplayName = displayName;
            Description = description;
            Url = url;
        }

        /// <summary>
        /// 设置父菜单。若菜单为空，表示没有父菜单
        /// </summary>
        /// <param name="parentId">要设置的父菜单</param>
        public void SetParent(Guid? parentId)
        {
            ParentId = parentId;
        }

        /// <summary>
        /// 激活菜单
        /// </summary>
        public void Activate()
        {
            IsActive = true;
        }

        /// <summary>
        /// 禁用菜单
        /// </summary>
        public void Inactivate()
        {
            IsActive = false;
        }

        #endregion
    }
}
