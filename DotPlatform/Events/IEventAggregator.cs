using System;

namespace DotPlatform.Events
{
    /// <summary>
    /// 事件聚合器。用于订阅(Subcribe)/取消(Unsubcribe)和发布(Publish)事件。
    /// </summary>
    public interface IEventAggregator
    {
        #region Register  subscriber

        /// <summary>
        /// 订阅事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型<see cref="IEvent"/></typeparam>
        /// <param name="handler">事件处理者<see cref="IEventHandler{TEvent}"/></param>
        void Subcribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : class, IEvent;

        /// <summary>
        /// 订阅事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型<see cref="IEvent"/></typeparam>
        /// <param name="handler">事件处理者<see cref="IEventHandler{TEvent}"/>集合</param>
        void Subcribe<TEvent>(params IEventHandler<TEvent>[] handlers) where TEvent : class, IEvent;

        #endregion

        #region Unsubcribe

        /// <summary>
        /// 取消事件订阅
        /// </summary>
        /// <typeparam name="TEvent">事件类型<see cref="IEvent"/></typeparam>
        /// <param name="handler">事件处理者<see cref="IEventHandler{TEvent}"/></param>
        void Unsubcribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : class, IEvent;

        #endregion

        #region Publish

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型<see cref="IEvent"/></typeparam>
        /// <param name="event">要发布的事件</param>
        void Publish<TEvent>(TEvent @event) where TEvent : class, IEvent;

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型<see cref="IEvent"/></typeparam>
        /// <param name="event">要发布的事件</param>
        /// <param name="callback">回调方法。在事件发布后执行</param>
        void Publish<TEvent>(TEvent @event, Action<TEvent, bool> callback) where TEvent : class, IEvent;

        #endregion
    }
}
