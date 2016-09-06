using AutoMapper;
using System.Collections.Generic;

namespace DotPlatform.AutoMapper
{
    /// <summary>
    /// 自动映射扩展类
    /// </summary>
    public static class AutoMapExtension
    {
        /// <summary>
        /// 从源对象映射到目标对象
        /// </summary>
        /// <typeparam name="TSource">源对象类型</typeparam>
        /// <typeparam name="TDesitination">映射到目标对象的类型</typeparam>
        /// <param name="source">源对象实例</param>
        /// <returns>目标对象</returns>
        public static TDesitination MapTo<TSource, TDesitination>(this TSource source)
        {
            return Mapper.Map<TDesitination>(source);
        }

        /// <summary>
        /// 从源对象映射到目标对象
        /// </summary>
        /// <typeparam name="TDesitination">映射到目标对象的类型</typeparam>
        /// <param name="source">源对象实例</param>
        /// <returns>目标对象</returns>
        public static TDesitination MapTo<TDesitination>(this object source)
        {
            return Mapper.Map<TDesitination>(source);
        }

        /// <summary>
        /// 从源对象映射到目标对象。
        /// 源对象必须为集合类型
        /// </summary>
        /// <typeparam name="TDesitination">映射到目标对象的类型</typeparam>
        /// <param name="source">源对象实例</param>
        /// <returns></returns>
        public static List<TDesitination> MapTo<TDesitination>(this IEnumerable<object> source)
        {
            return Mapper.Map<List<TDesitination>>(source);
        }
    }
}
