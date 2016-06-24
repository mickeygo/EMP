using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;

namespace DotPlatform.Events.Registrator
{
    /// <summary>
    /// 事件处理者注册容器。提供了对事件及事件处理者的对应关系的存储
    /// </summary>
    internal sealed class EventHandlerRegistrator
    {
        // Cache all event handlers.
        private static ConcurrentDictionary<Type, List<object>> eventHandlers = new ConcurrentDictionary<Type, List<object>>();
        private static EventHandlerRegistrator _instance = new EventHandlerRegistrator();

        private Func<object, object, bool> predicate = (obj1, obj2) =>
        {
            var o1Type = obj1.GetType();
            var o2Type = obj2.GetType();

            var equal = o1Type.IsGenericType && o2Type.IsGenericType
                    && o1Type.GetGenericTypeDefinition() == o2Type.GetGenericTypeDefinition()
                    && o1Type.GetGenericArguments().Count() == 1
                    && o2Type.GetGenericArguments().Count() == 1
                    && o1Type.GetGenericArguments()[0] == o2Type.GetGenericArguments()[0];

            if (equal)
            {
                return obj1.Equals(obj2);
            }

            return o1Type == o2Type;
        };

        /// <summary>
        /// 获取<see cref="EventHandlerRegistrator"/>的实例。单例模式。
        /// </summary>
        public static EventHandlerRegistrator Instance
        {
            get { return _instance; }
        }

        #region Public Methods

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型<see cref="IEvent"/></typeparam>
        /// <param name="handler">事件处理者<see cref="IEventHandler{TEvent}"/></param>
        public void Register<TEvent>(IEventHandler<TEvent> handler) where TEvent : class, IEvent
        {
            var eventType = typeof(TEvent);
            if (eventHandlers.ContainsKey(eventType))
            {
                var handlers = eventHandlers[eventType];

                if (!handlers.Exists(s => predicate(s, handler)))
                    handlers.Add((IEventHandler<IEvent>)handler);
            }
            else
            {
                var handlers = new List<object> { handler };
                eventHandlers.TryAdd(eventType, handlers);
            }
        }

        /// <summary>
        /// 取消已注册的事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型<see cref="IEvent"/></typeparam>
        /// <param name="handler">事件处理者<see cref="IEventHandler{TEvent}"/></param>
        public void Unregister<TEvent>(IEventHandler<TEvent> handler) where TEvent : class, IEvent
        {
            var eventType = typeof(TEvent);
            if (eventHandlers.ContainsKey(eventType))
            {
                var handlers = eventHandlers[eventType];
                if (handlers.Contains(handler))
                    handlers.Remove(handler);
            }
        }

        /// <summary>
        /// 获取注册的事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型<see cref="IEvent"/></typeparam>
        /// <returns>事件处理者集合</returns>
        public IEnumerable<IEventHandler<TEvent>> GetEvents<TEvent>() where TEvent : class, IEvent
        {
            List<object> handlers;
            if (eventHandlers.TryGetValue(typeof(TEvent), out handlers))
                return handlers.Cast<IEventHandler<TEvent>>();

            return null;
        }

        #endregion
    }
}
