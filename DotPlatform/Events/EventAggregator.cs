using System;
using DotPlatform.Events.Registrator;

namespace DotPlatform.Events
{
    /// <summary>
    /// 事件聚合器事件聚合器。用于订阅和发布事件。
    /// </summary>
    public class EventAggregator : IEventAggregator
    {
        private readonly EventHandlerRegistrator registrator;

        /// <summary>
        /// 初始化一个新的<c>EventAggregator</c>实例
        /// </summary>
        public EventAggregator()
        {
            registrator = EventHandlerRegistrator.Instance;
        }

        public void Subcribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : class, IEvent
        {
            registrator.Register(handler);
        }

        public void Subcribe<TEvent>(params IEventHandler<TEvent>[] handlers) where TEvent : class, IEvent
        {
            foreach (var handler in handlers)
            {
                Subcribe(handler);
            }
        }

        public void Unsubcribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : class, IEvent
        {
            registrator.Unregister(handler);
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            var handlers = registrator.GetEvents<TEvent>();
            if (handlers != null)
            {
                foreach (var handler in handlers)
                {
                    handler.Handle(@event);
                }
            }
        }

        public void Publish<TEvent>(TEvent @event, Action<TEvent, bool> callback) where TEvent : class, IEvent
        {
            var handlers = registrator.GetEvents<TEvent>();
            if (handlers == null)
            {
                callback(@event, false);
                return;
            }

            try
            {
                foreach (var handler in handlers)
                {
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
