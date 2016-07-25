using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace DotPlatform.Events.Registrator
{
    /// <summary>
    /// 事件与其处理者映射关系存储类
    /// </summary>
    internal sealed class EventHandlerMappingCache
    {
        // Cache all event handlers. One event type map one or more then one event handler type.
        private static ConcurrentDictionary<Type, List<Type>> EventHandlerMappingCollection = new ConcurrentDictionary<Type, List<Type>>();

        private EventHandlerMappingCache()
        {
        }

        /// <summary>
        /// 获取事件对应的处理器类型集合。若不存在，则返回 null.
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <returns>事件处理器类型集合</returns>
        public static List<Type> GetEventHandlerTypes(Type eventType)
        {
            List<Type> handlers;
            if (EventHandlerMappingCollection.TryGetValue(eventType, out handlers))
                return handlers;

            return null;
        }

        public static void Add(Type eventType, Type eventHandlerType)
        {
            if (EventHandlerMappingCollection.ContainsKey(eventType))
            {
                var handlers = EventHandlerMappingCollection[eventType];
                if (!handlers.Contains(eventHandlerType))
                    handlers.Add(eventHandlerType);
            }
            else
            {
                var handlers = new List<Type> { eventHandlerType };
                EventHandlerMappingCollection.TryAdd(eventType, handlers);
            }
        }

        public static void Remove(Type eventType, Type eventHandlerType)
        {
            List<Type> handlers;
            if (EventHandlerMappingCollection.TryGetValue(eventType, out handlers))
            {
                if (handlers.Contains(eventHandlerType))
                    handlers.Remove(eventHandlerType);
            }
        }

        /// <summary>
        /// 移除指定的事件处理者对应关系缓存
        /// </summary>
        /// <param name="eventType"></param>
        public static void Remove(Type eventType)
        {
            List<Type> handlers;
            EventHandlerMappingCollection.TryRemove(eventType, out handlers);
        }

        /// <summary>
        /// 清空所有的事件处理者对应关系缓存
        /// </summary>
        public static void Clear()
        {
            EventHandlerMappingCollection.Clear();
        }
    }
}
