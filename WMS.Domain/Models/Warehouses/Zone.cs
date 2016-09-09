using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace WMS.Domain.Models.Warehouses
{
    /// <summary>
    /// 仓库区域
    /// </summary>
    public class Zone : AggregateRoot, ISoftDelete, ICreationAudited, IModificationAudited
    {
        #region Properties

        /// <summary>
        /// 获取仓库区域名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; private set; }

        /// <summary>
        /// 获取或设置仓库区域显示名
        /// </summary>
        [StringLength(50)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 获取或设置仓库区域描述
        /// </summary>
        [StringLength(80)]
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置区域的长度(m)
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// 获取或设置区域的宽度(m)
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// 获取或设置区域的高度(m)
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// 获取仓库 Id
        /// </summary>
        public Guid WarehouseId { get; private set; }

        /// <summary>
        /// 获取仓库信息
        /// </summary>
        public virtual Warehouse Warehouse { get; private set; }

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

        public Zone()
        {

        }

        /// <summary>
        /// 初始化一个新的<see cref="Zone"/>实例
        /// </summary>
        /// <param name="name">区域名</param>
        /// <param name="displayName">区域显示名</param>
        /// <param name="description">区域描述</param>
        /// <param name="warehouseId">隶属的仓储 Id</param>
        public Zone(string name, string displayName, string description, Guid warehouseId)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
            WarehouseId = warehouseId;
        }

        #endregion
    }
}
