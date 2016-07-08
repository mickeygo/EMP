using System;

namespace DotPlatform.Domain.Entities
{
    /// <summary>
    /// 实现此接口的类为聚合根对象
    /// </summary>
    /// <typeparam name="TPrimaryKey">聚合根实体主键类型</typeparam>
    public interface IAggregateRoot<TPrimaryKey> : IEntity<TPrimaryKey>
    {
    }

    /// <summary>
    /// 实现此接口的类为聚合对象. 聚合根实体主键为 <see cref="Guid"/>
    /// </summary>
    public interface IAggregateRoot : IEntity, IAggregateRoot<Guid>
    {
        
    }
}
