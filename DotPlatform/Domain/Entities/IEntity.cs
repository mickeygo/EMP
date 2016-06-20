using System;

namespace DotPlatform.Domain.Entities
{
    /// <summary>
    /// 表示实现类为领域模型实体类
    /// </summary>
    /// <typeparam name="TPrimaryKey">实体主键类型</typeparam>
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 实体 Id
        /// </summary>
        TPrimaryKey Id { get; set; }

        /// <summary>
        /// 检查实体是否是临时的（没有在数据库中持久化，没有 <see cref="Id"/> 值）
        /// </summary>
        /// <returns>true 表示实体是临时的</returns>
        bool IsTransient();
    }

    /// <summary>
    /// 表示实现类为领域模型实体类。实体主键为 <see cref="Guid"/>
    /// </summary>
    public interface IEntity : IEntity<Guid>
    {
        
    }
}
