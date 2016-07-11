using System;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace DotPlatform.TestBase.Domain.Entities
{
    /// <summary>
    /// 订单明细
    /// </summary>
    public class OrderLine : Entity, ICreationAudited, IModificationAudited
    {
        public Guid OrderId { get; set; }

        public Order Order { get; private set; }

        public Guid ProductId { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual Product Product { get; private set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }

        public Guid CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid? LastModifierUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}
