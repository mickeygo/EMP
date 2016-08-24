using System;
using System.Threading.Tasks;
using DotPlatform.Events.Storage;

namespace DotPlatform.Events.Bus
{
    /// <summary>
    /// 事件总线
    /// </summary>
    public class EventBus : IEventBus
    {
        private readonly IDomainEventStorage _storage;
        private readonly IEventBusProvider _busProvider;

        public EventBus(IDomainEventStorage storage, IEventBusProvider busProvider)
        {
            _storage = storage;
            _busProvider = busProvider;
        }

        public Guid Id { get; } = Guid.NewGuid();

        public void Publish(IEvent @event)
        {
            var domainEvent = @event as IDomainEvent;
            if (domainEvent == null)
                throw new InvalidOperationException("Only the domain event can be published.");

            // 存储事件(领域事件)
            // Todo: 可思考如何将"事件存储"与"事件总线"分离
            StoreEvent(domainEvent);

            // 发布事件到对应的 Event Handler 上
            _busProvider.Bus.Publish(@event);
        }

        /// <summary>
        /// 存储领域事件
        /// </summary>
        private Task StoreEvent(IDomainEvent domainEvent)
        {
            return _storage.SaveAsync(domainEvent);
        }
    }
}
