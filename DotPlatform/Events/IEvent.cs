using System;
using DotPlatform.Bus;


namespace DotPlatform.Events
{
    /// <summary>
    /// 表示实现此接口饿类为事件
    /// </summary>
    public interface IEvent : IMessage
    {
        /// <summary>
        /// 获取事件的 Id. 每一个事件都是唯一的
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// 获取事件生成的时间戳。
        /// 为了避免在分布式时不同机器上生成的时间格式不同，这里统一使用 UTC 格式时间
        /// </summary>
        DateTimeOffset TimeStamp { get; }
    }
}
