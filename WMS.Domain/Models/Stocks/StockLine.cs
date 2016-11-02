using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace WMS.Domain.Models.Stocks
{
    /// <summary>
    /// 库存明细（记录 SN 信息）
    /// </summary>
    public class StockLine : AggregateRoot, IMustHaveTenant, ICreationAudited, IModificationAudited
    {
        #region Properties

        /// <summary>
        /// SN
        /// </summary>
        [Required]
        [StringLength(10)]
        public string SerialNumber { get; set; }

        /// <summary>
        /// SN 隶属的料号
        /// </summary>
        [Required]
        [StringLength(20)]
        public string PartNumber { get; set; }

        /// <summary>
        /// SN 状态
        /// </summary>
        public SnStatus Status { get; set; }

        public Guid TenantId { get; set; }

        public Guid CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid? LastModifierUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        #endregion
    }
}
