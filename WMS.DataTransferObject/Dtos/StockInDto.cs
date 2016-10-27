using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using DotPlatform.Application.Services.Dto;
using WMS.Domain.Models.Inbounds;
using DotPlatform.AutoMapper;

namespace WMS.DataTransferObject.Dtos
{
    /// <summary>
    /// 入库单 Dto 对象
    /// </summary>
    [AutoMapFrom(typeof(StockIn))]
    public class StockInDto : IEntityDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(15)]
        public string DocNo { get; set; }

        /// <summary>
        /// 来源工厂
        /// </summary>
        [StringLength(4)]
        public string Plant { get; set; }

        /// <summary>
        /// WIP 单号
        /// </summary>
        [StringLength(10)]
        public string WipNo { get; set; }

        /// <summary>
        /// 料号
        /// </summary>
        [StringLength(20)]
        public string PartNumber { get; set; }

        /// <summary>
        /// 单据明细数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 收料工厂
        /// </summary>
        [StringLength(4)]
        public string DestPlant { get; set; }

        /// <summary>
        /// 收料库位
        /// </summary>
        [StringLength(4)]
        public string DestLocation { get; set; }

        /// <summary>
        /// 单据备注
        /// </summary>
        [StringLength(256)]
        public string Remark { get; set; }

        /// <summary>
        /// 凭证号
        /// </summary>
        [StringLength(10)]
        public string Certificate { get; set; }

        /// <summary>
        /// 回执消息
        /// </summary>
        [StringLength(256)]
        public string AckMessage { get; set; }

        /// <summary>
        /// 新的 WIP 单号
        /// </summary>
        [StringLength(10)]
        public string NewWipNo { get; set; }

        /// <summary>
        /// 单据申请人
        /// </summary>
        [StringLength(80)]
        public string Applicant { get; set; }

        /// <summary>
        /// 单据申请时间
        /// </summary>
        public DateTime ApplicantDate { get; set; }

        /// <summary>
        /// 过账人
        /// </summary>
        [StringLength(80)]
        public string PostedBy { get; set; }

        /// <summary>
        /// 过账日期
        /// </summary>
        public DateTime? PostedDate { get; set; }

        /// <summary>
        /// 入库单单据状态
        /// </summary>
        public StockInStatusDto Status { get; set; }

        public Guid TenantId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public Guid? LastModifierUserId { get; set; }

        public Guid? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public List<StockInLineDto> StockInLines { get; set; }
    }
}
