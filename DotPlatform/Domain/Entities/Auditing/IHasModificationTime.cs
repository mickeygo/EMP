using System;

namespace DotPlatform.Domain.Entities.Auditing
{
    /// <summary>
    /// 表示实现此接口的实体<see cref="Entity"/>必须持久化此属性.
    /// 当实体<see cref="Entity"/>更新时<see cref="LastModificationTime"/>将自动储存
    /// </summary>
    public interface IHasModificationTime
    {
        /// <summary>
        /// 获取或设置实体的最后更新时间
        /// </summary>
        DateTime? LastModificationTime { get; set; }
    }
}
