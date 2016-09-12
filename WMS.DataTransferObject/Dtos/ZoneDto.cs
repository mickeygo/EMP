using System;
using DotPlatform.Application.Services.Dto;
using DotPlatform.AutoMapper;

namespace WMS.DataTransferObject.Dtos
{
    /// <summary>
    /// 仓库区域 Dto 对象
    /// </summary>
    [AutoMapFrom(typeof(Domain.Models.Warehouses.Zone))]
    public class ZoneDto : IEntityDto
    {
        /// <summary>
        /// 获取或设置仓库区域 Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 获取或设置仓库区域名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置仓库区域显示名
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 获取或设置仓库区域描述
        /// </summary>
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
        /// 获取或设置仓库 Id
        /// </summary>
        public Guid WarehouseId { get; set; }

        /// <summary>
        /// 获取仓库信息 Dto
        /// </summary>
        public WarehouseDto Warehouse { get; private set; }

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
