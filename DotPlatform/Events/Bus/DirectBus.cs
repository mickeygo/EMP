using DotPlatform.Bus;

namespace DotPlatform.Events.Bus
{
    /// <summary>
    /// 没有中间组件的总线。
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
        public void Publish(IMessage message)
        {
            _eventAggregator.Publish((IEvent)message);
        }
    }
}
