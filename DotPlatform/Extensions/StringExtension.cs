using System;

namespace DotPlatform.Extensions
{
    /// <summary>
    /// <see cref="string"/> 类型扩展类
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 将<see cref="string"/>转换为<see cref="Guid"/>类型。
        /// 若字符串为 Null 或 Empty，或是转换失败，将返回 默认值
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defaultValue">默认值，默认为 null</param>
        /// <returns></returns>
        public static Guid? ToGuid(this string str, Guid? defaultValue = null)
        {
            if (string.IsNullOrWhiteSpace(str))
                return null;

            Guid value;
            if (Guid.TryParse(str, out value))
                return value;

            return defaultValue;
        }

        /// <summary>
        /// 将<see cref="string"/>转换为<see cref="int"/>类型。
        /// 若字符串为 Null 或 Empty，或是转换失败，将返回 默认值
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defaultValue">默认值，默认为 null</param>
        /// <returns></returns>
        public static int? ToInt32(this string str, int? defaultValue = null)
        {
            if (string.IsNullOrWhiteSpace(str))
                return null;
                
            int value;
            if (int.TryParse(str, out value))
                return value;

            return defaultValue;
        }
    }
}
