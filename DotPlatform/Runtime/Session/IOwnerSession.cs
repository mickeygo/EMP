using System;

namespace DotPlatform.Runtime.Session
{
    /// <summary>
    /// 表示实现此接口的类为当前会话者的相关信息
    /// </summary>
    /// <typeparam name="TKey">会话信息主体<see cref="Domain.Entities.Entity"/>主键类型</typeparam>
    public interface IOwnerSession<TKey>
    {
        /// <summary>
        /// 是否已验证
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// 获取当前租户 Id 信息
        /// </summary>
        TKey TenantId { get; }

        /// <summary>
        /// 获取当前租户的时差
        /// </summary>
        int? TimeDifference { get; }

        /// <summary>
        /// 获取当前登录者 Id 信息
        /// </summary>
        TKey UserId { get; }
    }

    /// <summary>
    /// 表示实现此接口的类为当前会话者的相关信息。
    /// 其中实体<see cref="Domain.Entities.Entity"/>主键类型为 <see cref="System.Nullable{Guid}"/>
    /// </summary>
    public interface IOwnerSession : IOwnerSession<Guid?>
    {

    }
}
