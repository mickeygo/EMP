using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace WMS.Domain.Models.Warehouses
{
    /// <summary>
    /// 仓库储位
    /// </summary>
    public class Location : AggregateRoot, ISoftDelete, ICreationAudited, IModificationAudited
    {
        #region Properties

        /// <summary>
        /// 获取储位名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; private set; }

        /// <summary>
        /// 是否是保税储位
        /// </summary>
        public bool IsBonded { get; set; }

        /// <summary>
        /// 获取或设置储位的长度(m)
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 获取或设置储位的宽度(m)
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 获取或设置储位的高度(m)
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 获取货架 Id
        /// </summary>
        public Guid ShelfId { get; private set; }

        /// <summary>
        /// 获取货架信息
        /// </summary>
        public virtual Shelf Shelf { get; }

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

        public Location()
        {
        }

        /// <summary>
        /// 初始化一个新的<see cref="Location"/>实例
        /// </summary>
        /// <param name="name">储位名</param>
        /// <param name="shelfId">隶属的货架 Id</param>
        /// <param name="isBonded">是否是保税储位</param>
        public Location(string name, Guid shelfId, bool isBonded)
        {
            Name = name;
            ShelfId = shelfId;
            IsBonded = isBonded;
        }

        #endregion
    }
}
