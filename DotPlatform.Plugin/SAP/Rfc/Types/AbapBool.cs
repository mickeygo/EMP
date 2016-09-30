using System.Linq;
using DotPlatform.Plugin.SAP.Rfc.Exceptions;

namespace DotPlatform.Plugin.SAP.Rfc.Types
{
    /// <summary>
    /// ABAP bool 类型
    /// </summary>
    public static class AbapBool
    {
        private static string[] expectedValues = { "X", "", " " };

        /// <summary>
        /// 将 ABAP 中的表示 bool 的字符转换为 NET 中对应的值类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool FromString(string value)
        {
            if (expectedValues.Contains(value))
                return value == "X";

            throw new RfcMappingException($"'{value}' is not a valid boolean value");
        }

        /// <summary>
        /// 将 NET bool 类型转换为 ABAP 字符
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString(bool value)
        {
            return value ? "X" : " ";
        }
    }
}
