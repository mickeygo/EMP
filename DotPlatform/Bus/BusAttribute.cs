using System;

namespace DotPlatform.Bus
{
    /// <summary>
    /// Bus 特性，用于指定使用哪种 Bus 传递消息
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class BusAttribute : Attribute
    {
        /// <summary>
        /// 获取 Bus 模型
        /// </summary>
        public BusModel Model { get; private set; }

        /// <summary>
        /// 初始化一个新的<see cref="BusAttribute"/>实例。
        /// 默认使用 BusModel = 0 的 Bus 模型。
        /// </summary>
        public BusAttribute() : this(0)
        {

        }

        /// <summary>
        /// 初始化一个新的<see cref="BusAttribute"/>实例
        /// </summary>
        /// <param name="model">Bus 模型</param>
        public BusAttribute(BusModel model)
        {

        }
    }
}
