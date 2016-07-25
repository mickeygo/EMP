using System;

namespace DotPlatform.Events.DirectBus
{
    /// <summary>
    /// 没有中间组件的事件总线。
    /// </summary>
    public class DirectEventBus : IDirectEventBus
    {
        private readonly IEventAggregator _eventAggregator;

        public DirectEventBus(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        /// <summary>
        /// 获取事件总线 Id
        /// </summary>
        public Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        /// <summary>
        /// 发布事件
        /// </summary>
        public void Publish(IEvent @event)
        {
            _eventAggregator.Publish(@event);
        }
    }
}
