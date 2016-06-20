using System;

namespace DotPlatform.Domain.Entities.Auditing
{
    /// <summary>
    /// 表示实现此接口的实体<see cref="Entity"/>必须持久化此属性。
    /// 当实体<see cref="Entity"/>创建时<see cref="CreationTime"/>将自动储存
    /// </summary>
    public interface IHasCreationTime
    {
        /// <summary>
        /// 获取或设置实体的创建时间
        /// </summary>
        DateTime CreationTime { get; set; }
    }
}
