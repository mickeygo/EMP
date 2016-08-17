using System;

namespace DotPlatform.Domain.Entities.Extensions
{
    /// <summary>
    /// <see cref="IEntity"/>实体扩展类
    /// </summary>
    public static class EntityExtensions
    {
        /// <summary>
        /// 检查实体的 Id。
        /// 若实体 Id 不存在，会设置新的 Id 值
        /// </summary>
        /// <param name="entity">实体对象</param>
        public static void CheckOrSetEntityKeyIfNull(this IEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.IsTransient())
            {
                if (entity is Entity)
                {
                    (entity as Entity).GenerateNewId();
                }
            }
        }

        /// <summary>
        /// 将 Entity 对象转换为指定的实体对象。
        /// 若不能转换为指定对象，会抛出异常.
        /// </summary>
        /// <typeparam name="T">要转换的对象类型</typeparam>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public static T Cast<T>(this IEntity entity) where T : IEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (!(entity is T))
            {
                throw new DotPlatformException($"The {entity.GetType().AssemblyQualifiedName} can not convert to {typeof(T).AssemblyQualifiedName}");
            }

            return (T) entity ;
        }
    }
}
