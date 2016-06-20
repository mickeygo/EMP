using System;

namespace DotPlatform.Domain.Entities
{
    /// <summary>
    /// 表示实现接口的领域实体可以含有一个租户信息
    /// </summary>
    /// <typeparam name="TKey">租户主键类型</typeparam>
    public interface IMayHaveTenant<TKey>
    {
        /// <summary>
        /// 租户 Id
        /// </summary>
        TKey TenantId { get; set; }
    }

    /// <summary>
    /// 表示实现接口的领域实体可以含有一个租户信息。租户主键类型为 <see cref="System.Nullable{Guid}"/>
    /// </summary>
    public interface IMayHaveTenant : IMayHaveTenant<Guid?>
    {

    }
}
