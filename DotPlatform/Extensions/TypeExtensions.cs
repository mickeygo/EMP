using System;

namespace DotPlatform.Extensions
{
    /// <summary>
    /// Type 扩展类
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// 类型是否允许为空。
        /// 非值类型和可空类型都可以为 null .
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <returns></returns>
        public static bool IsNullable(this Type type)
        {
            if (!type.IsValueType)
                return true;

            return Nullable.GetUnderlyingType(type) != null;
        }
    }
}
