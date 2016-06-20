using System;

namespace DotPlatform.Domain.Entities.Auditing
{
    /// <summary>
    /// 表示实现此接口的实体是要储存修改者的信息，包含更新人和更新时间。
    /// 这些信息会自动存储到数据库中.
    /// </summary>
    /// <typeparam name="TKey">更新者<see cref="LastModifierUserId"/>的主键类型</typeparam>
    public interface IModificationAudited<TKey> : IHasModificationTime
    {
        /// <summary>
        /// 获取或设置实体修改者的 Id
        /// </summary>
        TKey LastModifierUserId { get; set; }
    }

    /// <summary>
    /// 表示实现此接口的实体是要储存修改者的信息，包含更新人和更新时间。
    /// 这些信息会自动存储到数据库中.
    /// 创建者实体的主键类型为 <see cref="System.Nullable{Guid}"/>
    /// </summary>
    public interface IModificationAudited : IModificationAudited<Guid?>
    {
        
    }
}
