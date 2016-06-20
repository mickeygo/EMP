using System;

namespace DotPlatform.Domain.Entities.Auditing
{
    /// <summary>
    /// 表示实现此接口的实体是要储存创建者的信息，包含创建人和创建时间。
    /// 这些信息会自动存储到数据库中.
    /// </summary>
    /// <typeparam name="TKey">创建者<see cref="CreatorUserId"/>的主键类型</typeparam>
    public interface ICreationAudited<TKey> : IHasCreationTime
    {
        /// <summary>
        /// 获取或设置实体创建者的 Id
        /// </summary>
        TKey CreatorUserId { get; set; }
    }

    /// <summary>
    /// 表示实现此接口的实体是要储存创建者的信息，包含创建人和创建时间。
    /// 这些信息会自动存储到数据库中.
    /// 创建者实体的主键类型为 <see cref="Guid"/>
    /// </summary>
    public interface ICreationAudited : ICreationAudited<Guid>
    {
    }
}
