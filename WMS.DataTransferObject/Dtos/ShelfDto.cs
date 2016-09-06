using System;
using DotPlatform.Application.Services.Dto;
using DotPlatform.AutoMapper;
using WMS.Domain.Models.Warehouses;

namespace WMS.DataTransferObject.Dtos
{
    /// <summary>
    /// 货架 Dto 对象
    /// </summary>
    [AutoMapFrom(typeof(Shelf))]
    public class ShelfDto : IDto
    {
        /// <summary>
        /// 获取或设置仓库货架 Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 获取或设置仓库名
        /// </summary>
        public string Name { get; set; }

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
        /// 获取或设置区域 Id
        /// </summary>
        public Guid ZoneId { get; set; }

        /// <summary>
        /// 获取区域信息 Dto
        /// </summary>
        public ZoneDto Zone { get; private set; }

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
