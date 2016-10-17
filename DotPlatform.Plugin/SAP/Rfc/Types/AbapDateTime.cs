using System;
using System.Globalization;
using DotPlatform.Plugin.SAP.Rfc.Exceptions;

namespace DotPlatform.Plugin.SAP.Rfc.Types
{
    /// <summary>
    /// ABAP 日期类型
    /// </summary>
    public static class AbapDateTime
    {
        private static CultureInfo enUS = new CultureInfo("en-US");

        /// <summary>
        /// 将 ABAP 的时间转换为 .NET 时间
        /// </summary>
        /// <param name="value">APAB 的时间字符串</param>
        /// <param name="acceptNull">是否允许接收空值</param>
        /// <returns></returns>
        public static DateTime? FromString(string value, bool acceptNull = false)
        {
            DateTime date;

            // ABAP Date and Time initial value
            if (value == "00000000" || value == "000000" ||
                value == "00:00:00" || value == "0000-00-00")
            {
                if (acceptNull)
                    return null;
                return DateTime.MinValue;
            }

            if (DateTime.TryParseExact(value, new string[] { "yyyy-MM-dd", "yyyyMMdd" }, enUS, DateTimeStyles.AssumeLocal, out date))
                return date;

            if (DateTime.TryParseExact(value, new string[] { "HH:mm:ss", "HHmmss" }, enUS, DateTimeStyles.AssumeLocal, out date))
                return DateTime.MinValue.Add(new TimeSpan(date.Hour, date.Minute, date.Second));

            throw new RfcMappingException($"{value} is not a valid Date format.");
        }

        /// <summary>
        /// 将 .NET 时间转换 ABAP 日期格式，格式为 yyyyMMdd 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDateString(DateTime value)
        {
            return value.ToString("yyyyMMdd");
        }

        /// <summary>
        /// 将 .NET 时间转换为 ABAP 时间，格式为 HHmmss
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTimeString(DateTime value)
        {
            return value.ToString("HHmmss");
        }
    }
}
