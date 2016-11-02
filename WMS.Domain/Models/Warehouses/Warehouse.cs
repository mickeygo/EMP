using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace WMS.Domain.Models.Warehouses
{
    /// <summary>
    /// 仓库聚合根
    /// </summary>
    public class Warehouse : AggregateRoot, ISoftDelete, IMustHaveTenant, ICreationAudited, IModificationAudited
    {
        #region Properties

        /// <summary>
        /// 获取仓库名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; private set; }

        /// <summary>
        /// 获取或设置仓库显示名
        /// </summary>
        [StringLength(50)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 获取或设置仓库描述
        /// </summary>
        [StringLength(80)]
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置仓库的长度(m)
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// 获取或设置仓库的宽度(m)
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// 获取或设置仓库的高度(m)
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// 获取或设置隶属的租户
        /// </summary>
        public Guid TenantId { get; set; }

        /// <summary>
        /// 是否已删除
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
        /// 获取或设置更新人
        /// </summary>
        public Guid? LastModifierUserId { get; set; }

        /// <summary>
        /// 获取或设置更新时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }

        #endregion

        #region Ctor

        public Warehouse()
        {

        }

        /// <summary>
        /// 初始化一个新的<see cref="Warehouse"/>实例
        /// </summary>
        /// <param name="name">仓库名称</param>
        /// <param name="displayName">仓库显示名称</param>
        /// <param name="description">参考描述</param>
        /// <param name="length">仓库长度</param>
        /// <param name="width">仓库宽度</param>
        /// <param name="height">仓库高度</param>
        public Warehouse(string name, string displayName, string description, double length, double width, double height)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
            Length = length;
            Width = width;
            Height = height;
        }

        #endregion
    }
}
