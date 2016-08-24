using System;

namespace DotPlatform.Authorization
{
    /// <summary>
    /// 用于指定 Controller 或 Action 等允许以何种方式访问
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ActorAttribute : Attribute
    {
        /// <summary>
        /// 获取行动模式
        /// </summary>
        public ActorMode Mode { get; }

        /// <summary>
        /// 初始化一个新的<see cref="ActorAttribute"/>实例
        /// </summary>
        /// <param name="mode">要设置的行为模式, 默认为 <see cref="ActorMode.None"/></param>
        public ActorAttribute(ActorMode mode = ActorMode.None)
        {
            Mode = mode;
        }
    }
}
