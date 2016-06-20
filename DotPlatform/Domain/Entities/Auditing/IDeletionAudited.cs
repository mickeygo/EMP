using System;

namespace DotPlatform.Domain.Entities.Auditing
{
    /// <summary>
    /// 表示实现此接口的实体是要储存删除者的信息，包含删除人和删除时间。
    /// 这些信息会自动存储到数据库中.
    /// </summary>
    /// <typeparam name="TKey">更新者<see cref="DeleterUserId"/>的主键类型</typeparam>
    public interface IDeletionAudited<TKey> : IHasDeletionTime
    {
        /// <summary>
        /// 获取或设置实体删除者的 Id
        /// </summary>
        TKey DeleterUserId { get; set; }
    }

    /// <summary>
    /// 表示实现此接口的实体是要储存删除者的信息，包含删除人和删除时间。
    /// 这些信息会自动存储到数据库中.
    /// 创建者实体的主键类型为 <see cref="System.Nullable{Guid}"/>
    /// </summary>
    public interface IDeletionAudited : IDeletionAudited<Guid?>
    {
        
    }
}
