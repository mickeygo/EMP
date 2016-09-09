using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Application.Services.Dto;
using DotPlatform.AutoMapper;
using WMS.Domain.Models.Warehouses;

namespace WMS.DataTransferObject.Dtos
{
    /// <summary>
    /// 仓库 Dto 对象
    /// </summary>
    [AutoMapFrom(typeof(Warehouse))]
    public class WarehouseDto : IDto
    {
        /// <summary>
        /// 获取或设置仓库 Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 获取或设置仓库名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置仓库显示名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 获取或设置仓库描述
        /// </summary>
        [Required]
        [StringLength(80)]
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置仓库的长度(m)
        /// </summary>
        [Range(0, 999)]
        public double Length { get; set; }

        /// <summary>
        /// 获取或设置仓库的宽度(m)
        /// </summary>
        [Range(0, 999)]
        public double Width { get; set; }

        /// <summary>
        /// 获取或设置仓库的高度(m)
        /// </summary>
        [Range(0, 10)]
        public double Height { get; set; }

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
