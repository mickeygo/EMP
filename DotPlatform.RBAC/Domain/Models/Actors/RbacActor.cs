using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace DotPlatform.RBAC.Domain.Models.Actors
{
    /// <summary>
    /// RBAC 权限管理，行为信息。只有处于 Active 状态的行为才能允许被访问.
    /// </summary>
    public class RbacActor : AggregateRoot, ISoftDelete, ICreationAudited, IModificationAudited
    {
        #region Properties

        /// <summary>
        /// 获取行为的唯一名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; }

        /// <summary>
        /// 获取行为的显示名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string DisplayName { get; private set; }

        /// <summary>
        /// 获取行为菜单描述
        /// </summary>
        [StringLength(80)]
        public string Description { get; private set; }

        /// <summary>
        /// 基于 MVC 的 Area
        /// </summary>
        [StringLength(20)]
        public string Area { get; private set; }

        /// <summary>
        /// 基于 MVC 的 Controller
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Controller { get; private set; }

        /// <summary>
        /// 基于 MVC 的 Action
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Action { get; private set; }

        /// <summary>
        /// 获取一个<see cref="bool"/>值，表示行为是否可用
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// 获取或设置一个<see cref="bool"/>值，表示行为是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 获取或设置行为创建人
        /// </summary>
        public Guid CreatorUserId { get; set; }

        /// <summary>
        /// 获取或设置行为创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 获取或设置行为最后更新人
        /// </summary>
        public Guid? LastModifierUserId { get; set; }

        /// <summary>
        /// 获取或设置行为最后更新时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }

        #endregion

        #region Ctor

        public RbacActor()
        {
        }

        /// <summary>
        /// 初始化一个新的<see cref="RbacActor"/>实例
        /// </summary>
        /// <param name="name">唯一的行为名称</param>
        /// <param name="displayName">行为显示名</param>
        /// <param name="description">行为描述</param>
        /// <param name="area">基于 MVC 的 Area</param>
        /// <param name="controller">基于 MVC 的 Controller</param>
        /// <param name="action">基于 MVC 的 Action</param>
        public RbacActor(string name, string displayName, string description, string area, string controller, string action)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
            Area = area;
            Controller = controller;
            Action = action;

            Activate();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 更新行为型
        /// </summary>
        /// <param name="displayName">行为显示名</param>
        /// <param name="description">行为描述</param>
        public void Update(string displayName, string description)
        {
            DisplayName = displayName;
            Description = description;

        }

        /// <summary>
        /// 设置行为
        /// </summary>
        /// <param name="area">基于 MVC 的 Area</param>
        /// <param name="controller">基于 MVC 的 Controller</param>
        /// <param name="action">基于 MVC 的 Action</param>
        public void SetAction(string area, string controller, string action)
        {
            Area = area;
            Controller = controller;
            Action = action;
        }

        /// <summary>
        /// 激活行为
        /// </summary>
        public void Activate()
        {
            IsActive = true;
        }

        /// <summary>
        /// 禁用行为
        /// </summary>
        public void Inactivate()
        {
            IsActive = false;
        }

        #endregion
    }
}
