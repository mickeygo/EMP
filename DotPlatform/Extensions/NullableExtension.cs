using System;

namespace DotPlatform.Extensions
{
    /// <summary>
    /// 可空类型的扩展方法类
    /// </summary>
    public static class NullableExtension
    {
        /// <summary>
        /// 将可空类型的值转换为非空的值类型。
        /// 若值为 null，将用默认值代替
        /// </summary>
        /// <typeparam name="T">可空类型</typeparam>
        /// <param name="i"></param>
        /// <param name="defaultValve">默认值，默认为 default(T)</param>
        /// <returns>非可空值</returns>
        public static T ToStruct<T>(this Nullable<T> i, T defaultValve = default(T))
            where T : struct
        {
            return i.HasValue ? i.Value : defaultValve;
        }
    }
}
