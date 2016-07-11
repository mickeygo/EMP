using System;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;

namespace DotPlatform.TestBase.Domain.Entities
{
    /// <summary>
    /// 产品
    /// </summary>
    public class Product : AggregateRoot, ICreationAudited, IModificationAudited, IDeletionAudited, ISoftDelete
    {
        /// <summary>
        /// 产品名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 产品型号
        /// </summary>
        public string Model { get; set; }

        public bool IsDeleted { get; set; }

        public Guid CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid? LastModifierUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public Guid? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }
    }
}
