using DotPlatform.Bus;

namespace DotPlatform.Events.Bus
{
    /// <summary>
    /// 简单的领域 Bus 提供者，没有中间消息组件
    /// </summary>
    public class EventBusProvider : IEventBusProvider
    {
        public EventBusProvider(IBus bus)
        {
            // Todo: 可以根据 Attribute 自由选择 Bus
            Bus = bus;
        }

        public IBus Bus { get; private set; }
    }
}
