using System;
using System.Collections.Generic;
using System.Linq;

namespace DotPlatform.Events.Registrator
{
    /// <summary>
    /// 事件处理者注册容器。提供了对事件及事件处理者的对应关系的存储.
    /// 注：注册器中会注册所有的事件及其处理者对应关系
    /// </summary>
    internal sealed class EventHandlerRegistrator
    {
        private static EventHandlerRegistrator _instance = new EventHandlerRegistrator();

        /// <summary>
        /// 获取<see cref="EventHandlerRegistrator"/>的实例。单例模式。
        /// </summary>
        public static EventHandlerRegistrator Instance
        {
            get { return _instance; }
        }

        #region Public Methods

        /// <summary>
        /// 注册事件处理器类型
        /// </summary>
        /// <param name="eventHandlerType">要注册的事件处理器类型</param>
        public void Register(Type eventHandlerType)
        {
            var eventType = GetEventTypeFromEventHandler(eventHandlerType); // Key
            EventHandlerMappingCache.Add(eventType, eventHandlerType);
        }

        /// <summary>
        /// 取消注册事件处理器类型
        /// </summary>
        /// <param name="eventHandlerType">要注册的事件处理器类型</param>
        public void Unregister(Type eventHandlerType)
        {
            var eventType = GetEventTypeFromEventHandler(eventHandlerType); // Key
            EventHandlerMappingCache.Remove(eventType, eventHandlerType);
        }

        /// <summary>
        /// 获取事件对应的处理器类型集合,若不存在，会返回 null.
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <returns>事件处理器类型集合</returns>
        public IEnumerable<Type> GetEvents(Type eventType)
        {
            return EventHandlerMappingCache.GetEventHandlerTypes(eventType);
        }

        #endregion

        #region Private Methods

        private Type GetEventTypeFromEventHandler(Type eventHandler)
        {
            var eventHandlerInterface = eventHandler.GetInterfaces().Single();
            return eventHandlerInterface.GetGenericArguments().Single();
        }

        #endregion
    }
}
