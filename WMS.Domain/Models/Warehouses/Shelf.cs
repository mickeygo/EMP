using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace WMS.Domain.Models.Warehouses
{
    /// <summary>
    /// 仓库货架
    /// </summary>
    public class Shelf : AggregateRoot, ISoftDelete, ICreationAudited, IModificationAudited
    {
        #region Properties

        /// <summary>
        /// 获取仓库名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; private set; }

        /// <summary>
        /// 获取或设置货架的长度(m)
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 获取或设置货架的宽度(m)
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 获取或设置货架的高度(m)
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 获取区域 Id
        /// </summary>
        public Guid ZoneId { get; private set; }

        /// <summary>
        /// 获取区域信息
        /// </summary>
        public virtual Zone Zone { get; private set; }

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

        public Shelf()
        {
        }

        /// <summary>
        /// 初始化一个新的<see cref="Shelf"/>实例
        /// </summary>
        /// <param name="name">货架名</param>
        /// <param name="zoneId">隶属的区域 Id</param>
        public Shelf(string name, Guid zoneId)
        {
            Name = name;
            ZoneId = zoneId;
        }

        #endregion
    }
}
