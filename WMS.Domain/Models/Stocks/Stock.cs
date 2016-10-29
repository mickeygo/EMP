using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;
using WMS.Domain.Models.Warehouses;

namespace WMS.Domain.Models.Stocks
{
    /// <summary>
    /// 库存
    /// </summary>
    public class Stock : AggregateRoot, IMustHaveTenant, ICreationAudited, IModificationAudited
    {
        #region Properties

        /// <summary>
        /// 储位 Id
        /// </summary>
        public Guid LocationId { get; set; }

        /// <summary>
        /// 储位
        /// </summary>
        public virtual Location Location { get; private set; }

        /// <summary>
        /// 料号
        /// </summary>
        [Required]
        [StringLength(20)]
        public string PartNumber { get; private set; }

        /// <summary>
        /// 在库数量
        /// </summary>
        [MinLength(0)]
        public int Onhand { get; private set; }

        public Guid TenantId { get; set; }

        public Guid CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid? LastModifierUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        #endregion

        #region Ctor


        #endregion
    }
}
