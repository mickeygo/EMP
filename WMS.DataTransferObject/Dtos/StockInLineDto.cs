using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Application.Services.Dto;
using WMS.Domain.Models.Inbounds;
using DotPlatform.AutoMapper;

namespace WMS.DataTransferObject.Dtos
{
    /// <summary>
    /// 入库单明细 Dto 对象
    /// </summary>
    [AutoMapFrom(typeof(StockInLine))]
    public class StockInLineDto : IEntityDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 入库单 Id
        /// </summary>
        public Guid StockInId { get; set; }

        /// <summary>
        /// 获取 Barcode
        /// </summary>
        [Required]
        [StringLength(10)]
        public string Barcode { get; set; }

        /// <summary>
        /// 获取箱号
        /// </summary>
        [Required]
        [StringLength(13)]
        public string CartonNo { get; set; }
    }
}
