using DotPlatform.Bus;

namespace DotPlatform.Events.Bus
{
    /// <summary>
    /// 表示实现此接口的类为事件总线提供者
    /// </summary>
    public interface IEventBusProvider
    {
        /// <summary>
        /// 获取 Bus
        /// </summary>
        IBus Bus { get; }
    }
}
