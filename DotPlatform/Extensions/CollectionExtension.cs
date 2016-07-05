using System.Collections.Generic;
using System.Linq;

namespace DotPlatform.Extensions
{
    /// <summary>
    /// 关于集合的扩展类
    /// </summary>
    public static class CollectionExtension
    {
        /// <summary>
        /// 判断集合是否为 null 或集合中没有数据
        /// </summary>
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null && !source.Any();
        }
    }
}
