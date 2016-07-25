using System;

namespace DotPlatform.Events
{
    /// <summary>
    /// 表示实现接口的类为事件总线。
    /// EventBus 用于将事件发布到指定的事件处理器上
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        /// 获取事件总线的 Id
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// 发布事件。
        /// 将事件发布到指定的事件处理器上，同一事件的事件处理器可以有多个。
        /// </summary>
        /// <param name="event">要发布的事件<see cref="IEvent"/></param>
        void Publish(IEvent @event);
    }
}
