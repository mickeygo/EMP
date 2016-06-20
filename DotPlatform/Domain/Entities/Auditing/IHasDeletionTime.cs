using System;

namespace DotPlatform.Domain.Entities.Auditing
{
    /// <summary>
    /// 表示实现此接口的实体必须持久化此属性。
    /// 当实体<see cref="Entity"/>删除时<see cref="DeletionTime"/>将自动储存
    /// </summary>
    public interface IHasDeletionTime
    {
        /// <summary>
        /// 获取或设置实体的删除时间
        /// </summary>
        DateTime? DeletionTime { get; set; }
    }
}
