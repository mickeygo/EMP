using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotPlatform.Domain.Entities;

namespace DotPlatform.Events.Storage
{
    /// <summary>
    /// 基于 Database 的领域事件存储
    /// </summary>
    internal class InDbDomainEventStorage : IDomainEventStorage
    {
        public void Save(IDomainEvent domainEvent)
        {
            var eventData = CreateDomainEventData(domainEvent);

            // Todo：存储领域事件数据到 DB
        }

        public async Task SaveAsync(IDomainEvent domainEvent)
        {
            await Task.FromResult(0);
        }

        public IEnumerable<IDomainEvent> Load(Type aggregateRootType, Guid aggregateRootId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDomainEvent> Load(Type aggregateRootType, Guid aggregateRootId, int version)
        {
            throw new NotImplementedException();
        }

        // 根据领域事件创建其数据包
        private DomainEventData<IEntity> CreateDomainEventData(IDomainEvent domainEvent)
        {
            var eventType = domainEvent.Source.GetType();
            var eventDataType = typeof(DomainEventData<>).MakeGenericType(eventType);
            return (DomainEventData<IEntity>)Activator.CreateInstance(eventDataType, domainEvent);
        }
    }
}
