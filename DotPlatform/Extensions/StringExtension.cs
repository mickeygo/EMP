using System;
using System.Linq;

namespace DotPlatform.Extensions
{
    /// <summary>
    /// <see cref="string"/> 类型扩展类
    /// </summary>
    public static class StringExtension
    {
        #region Convert

        /// <summary>
        /// 将 <see cref="string"/> 转换为 <see cref="Guid"/> 类型。
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
        /// 将 <see cref="string"/> 转换为 <see cref="int"/> 类型。
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

        #endregion

        #region String

        /// <summary>
        /// 判断字符串是否是 null 或 Empty
        /// </summary>
        /// <param name="str">要判断的字符串</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 判断字符串是否是 null、Empty 或 只包含空白字符
        /// </summary>
        /// <param name="str">要判断的字符串</param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// 字符串是否以指定的字符串数组中的任何一个开头,区分大小写
        /// </summary>
        /// <param name="str">要匹配的字符串</param>
        /// <param name="prefixs">指定前缀的字符串数组</param>
        /// <returns></returns>
        public static bool StartsIn(this string str, params string[] prefixs)
        {
            if (prefixs == null)
                throw new ArgumentNullException(nameof(prefixs));

            return prefixs.Any(p => str.StartsWith(p));
        }

        /// <summary>
        /// 字符串是否以指定的字符串数组中的任何一个结束,区分大小写
        /// </summary>
        /// <param name="str">要匹配的字符串</param>
        /// <param name="ends">指定后缀的字符串数组</param>
        /// <returns></returns>
        public static bool EndsIn(this string str, params string[] ends)
        {
            if (ends == null)
                throw new ArgumentNullException(nameof(ends));

            return ends.Any(p => str.EndsWith(p));
        }

        #endregion

        #region Split

        /// <summary>
        /// 分割字符串。分割后，移除为 Empty 的实体.
        /// 若要分割的字符串为 null, 返回结果也为 null.
        /// </summary>
        /// <param name="str">要分割的字符串</param>
        /// <param name="separator">分隔符集合</param>
        /// <returns></returns>
        public static string[] SplitWithoutEmpty(this string str, params char[] separator)
        {
            return str?.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

        #endregion
    }
}
