using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotPlatform.Events.Storage
{
    /// <summary>
    /// Null 的领域事件存储
    /// </summary>
    internal class NullDomainEventStorage : IDomainEventStorage
    {
        public void Save(IDomainEvent domainEvent)
        {
            
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
    }
}
