using DotPlatform.Domain.Entities;

namespace DotPlatform.Events
{
    /// <summary>
    /// 表示实现此接口的类为领域事件。
    /// 领域事件会涉及到领域实体操作。
    /// </summary>
    public interface IDomainEvent : IEvent
    {
        /// <summary>
        /// 获取事件源。事件源见<see cref="IEntity"/>
        /// </summary>
        IEntity Source { get; }

        /// <summary>
        /// 获取领域事件的版本号。
        /// </summary>
        int Version { get; }
    }
}
