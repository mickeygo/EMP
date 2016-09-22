using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Application.Services.Dto;
using DotPlatform.AutoMapper;
using WMS.Domain.Models.Warehouses;


namespace WMS.DataTransferObject.Dtos
{
    /// <summary>
    /// 储位 Dto 对象
    /// </summary>
    [AutoMapFrom(typeof(Location))]
    public class LocationDto : IEntityDto
    {
        /// <summary>
        /// 获取或设置仓库储位 Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 获取或设置仓库储位名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 是否是保税储位
        /// </summary>
        public bool IsBonded { get; set; }

        /// <summary>
        /// 获取或设置储位的长度(m)
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// 获取或设置储位的宽度(m)
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// 获取或设置储位的高度(m)
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// 获取或设置货架 Id
        /// </summary>
        public Guid ShelfId { get; set; }

        /// <summary>
        /// 获取货架信息 Dto
        /// </summary>
        public ShelfDto Shelf { get; private set; }

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
    }
}
