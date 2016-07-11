using System;
using System.Collections.Generic;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace DotPlatform.TestBase.Domain.Entities
{
    /// <summary>
    /// 订单
    /// </summary>
    public class Order : AggregateRoot, ICreationAudited, IModificationAudited, IDeletionAudited, ISoftDelete
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 订单明细项
        /// </summary>
        public virtual List<OrderLine> OrderLines { get; set; }


        public bool IsDeleted { get; set; }

        public Guid CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid? LastModifierUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public Guid? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

    }
}
