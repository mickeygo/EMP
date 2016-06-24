namespace DotPlatform.Events
{
    /// <summary>
    /// 表示实现此接口的类为事件处理者
    /// </summary>
    /// <typeparam name="TEvent">要处理的事件类型, <see cref="IEvent"/></typeparam>
    public interface IEventHandler<in TEvent> where TEvent : class, IEvent
    {
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="e">要处理的事件</param>
        void Handle(TEvent e);
    }
}
