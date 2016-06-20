using System;

namespace DotPlatform.Timing
{
    /// <summary>
    /// 时间操作
    /// </summary>
    public static class Clock
    {
        public static IClockProvider Provider { get; set; }

        static Clock()
        {
            Provider = new LocalClockProvider();
        }

        /// <summary>
        /// 获取系统当前时间
        /// </summary>
        public static DateTime System
        {
            get { return Provider.System; }
        }

        /// <summary>
        /// 获取在当前区域的当前时间
        /// </summary>
        public static DateTime Local
        {
            get { return Provider.Local; }
        }
    }
}
