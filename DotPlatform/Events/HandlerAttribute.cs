using System;

namespace DotPlatform.Events
{
    /// <summary>
    /// 应用了此特性的方法，在应用程序初始化时会自动将事件注册到事件处理者中。
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class HandlerAttribute : Attribute
    {
        /// <summary>
        /// 获取或设置事件的事件处理者类型
        /// </summary>
        public Type EventHandler { get; set; }

        /// <summary>
        /// 初始化一个新的<c>HandlerAttribute</c>实例
        /// </summary>
        /// <param name="eventHandler">事件处理者的类型</param>
        public HandlerAttribute(Type eventHandler)
        {
            EventHandler = eventHandler;
        }
    }
}
