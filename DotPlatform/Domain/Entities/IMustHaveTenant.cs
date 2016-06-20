using System;

namespace DotPlatform.Domain.Entities
{
    /// <summary>
    /// 表示实现接口的领域实体必须包含一个租户信息
    /// </summary>
    /// <typeparam name="Tkey">租户主键类型</typeparam>
    public interface IMustHaveTenant<Tkey>
    {
        /// <summary>
        /// 租户 Id
        /// </summary>
        Tkey TenantId { get; set; }
    }

    /// <summary>
    /// 表示实现接口的领域实体必须包含一个租户信息。租户主键类型为 <see cref="Guid"/>
    /// </summary>
    public interface IMustHaveTenant : IMustHaveTenant<Guid>
    {
        
    }
}
