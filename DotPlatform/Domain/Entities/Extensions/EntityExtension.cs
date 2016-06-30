using DotPlatform.Generators;

namespace DotPlatform.Domain.Entities.Extensions
{
    /// <summary>
    /// <see cref="IEntity"/>实体扩展类
    /// </summary>
    public static class EntityExtension
    {
        /// <summary>
        /// 检查实体的 Id。
        /// 若实体 Id 不存在，会设置 Id 值
        /// </summary>
        /// <param name="entity">实体对象</param>
        public static void CheckOrSetEntityKeyIfNull(this IEntity entity)
        {
            if (entity.IsTransient())
            {
                entity.Id = SequentialGuidGenerator.Instance.Create();
            }
        }
    }
}
