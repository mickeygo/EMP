using System;
using DotPlatform.Domain.Entities;

namespace DotPlatform.Events
{
    /// <summary>
    /// 领域事件数据.用户对领域事件进行封装。
    /// </summary>
    [Serializable]
    public class DomainEventData<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// 获取或设置事件 Id
        /// </summary>
        public Guid EventId { get; set; }

        /// <summary>
        /// 获取或设置事件类型的完全限定名称
        /// </summary>
        public string EventTypeName { get; set; }

        /// <summary>
        /// 获取或设置聚合根的类型的完全限定名称
        /// </summary>
        public string AggregateRootTypeName { get; set; }

        /// <summary>
        /// 获取或设置聚合根 Id
        /// </summary>
        public Guid AggregateRootId { get; set; }

        /// <summary>
        /// 获取或设置实体对象
        /// </summary>
        public TEntity Source { get; set; }

        /// <summary>
        /// 获取或设置事件的版本号
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 获取或设置事件生成的时间戳
        /// </summary>
        public DateTimeOffset TimeStamp { get; set; }

        /// <summary>
        /// 初始化一个新的<see cref="DomainEventData"/>实例
        /// </summary>
        public DomainEventData()
        {
        }

        /// <summary>
        /// 初始化一个新的<see cref="DomainEventData"/>实例
        /// </summary>
        /// <param name="domainEvent">领域事件</param>
        public DomainEventData(IDomainEvent domainEvent)
        {
            EventId = domainEvent.Id;
            EventTypeName = domainEvent.GetType().AssemblyQualifiedName;
            AggregateRootTypeName = domainEvent.Source.GetType().AssemblyQualifiedName;
            AggregateRootId = domainEvent.Source.Id;
            Source = (TEntity)domainEvent.Source;
            Version = domainEvent.Version;
            TimeStamp = domainEvent.TimeStamp;
        }
    }
}
