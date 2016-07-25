using System;
using DotPlatform.Events.Registrator;
using DotPlatform.Dependency;

namespace DotPlatform.Events
{
    /// <summary>
    /// 事件聚合器事件聚合器。用于订阅和发布事件。
    /// </summary>
    public class EventAggregator : IEventAggregator
    {
        private readonly EventHandlerRegistrator registrator;

        /// <summary>
        /// 初始化一个新的<see cref="EventAggregator"/>实例
        /// </summary>
        public EventAggregator()
        {
            registrator = EventHandlerRegistrator.Instance;
        }

        /// <summary>
        /// 订阅事件
        /// </summary>
        public void Subcribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : class, IEvent
        {
            
        }

        /// <summary>
        /// 订阅事件
        /// </summary>
        public void Subcribe<TEvent>(params IEventHandler<TEvent>[] handlers) where TEvent : class, IEvent
        {
            
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        public void Unsubcribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : class, IEvent
        {
            
        }

        /// <summary>
        /// 发布事件
        /// </summary>
        public void Publish<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            var handlerTypes = registrator.GetEvents(@event.GetType());
            if (handlerTypes != null)
            {
                foreach (var handlerType in handlerTypes)
                {
                    var handler = IocManager.Instance.Resolve(handlerType) as IEventHandler<TEvent>;
                    if (handler != null)
                        handler.Handle(@event);
                }
            }
        }

        /// <summary>
        /// 发布事件
        /// </summary>
        public void Publish<TEvent>(TEvent @event, Action<TEvent, bool> callback) where TEvent : class, IEvent
        {
            var handlerTypes = registrator.GetEvents(@event.GetType());
            if (handlerTypes == null)
            {
                callback(@event, false);
                return;
            }

            try
            {
                foreach (var handlerType in handlerTypes)
                {
                    var handler = IocManager.Instance.Resolve(handlerType) as IEventHandler<TEvent>;
                    if (handler != null)
                        handler.Handle(@event);
                }

                callback(@event, true);
            }
            catch (Exception)
            {
                callback(@event, false);
            }
        }
    }
}
