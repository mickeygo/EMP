using System.Threading.Tasks;
using DotPlatform.Bus;

namespace DotPlatform.Events.Bus
{
    /// <summary>
    /// 没有中间组件的总线。可用于 Command 总线和 Event 总线
    /// </summary>
    public class DirectBus : IBus
    {
        private readonly IEventAggregator _eventAggregator;

        public DirectBus(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        /// <summary>
        /// 发布事件
        /// </summary>
        public void Publish<TMessage>(TMessage message) 
            where TMessage : IMessage
        {
            _eventAggregator.Publish((IEvent)message);
        }

        public async Task PublishAsync<TMessage>(TMessage message) 
            where TMessage : IMessage
        {
            await Task.Run(() => _eventAggregator.Publish((IEvent)message));
        }
    }
}
