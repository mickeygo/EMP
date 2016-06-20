using System;

namespace DotPlatform.Domain.Entities
{
    /// <summary>
    /// 聚合根对象.
    /// </summary>
    /// <typeparam name="TPrimaryKey">聚合根实体主键类型</typeparam>
    [Serializable]
    public abstract class AggregateRoot<TPrimaryKey> : Entity<TPrimaryKey>, IAggregateRoot<TPrimaryKey>
    {
    }

    /// <summary>
    /// 聚合根对象. 聚合根实体主键为 <see cref="Guid"/>
    /// </summary>
    [Serializable]
    public abstract class AggregateRoot : AggregateRoot<Guid>
    {
        
    }
}
