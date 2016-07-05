using DotPlatform.Dependency;
using System;

namespace DotPlatform.Timing
{
    /// <summary>
    /// 时间操作
    /// </summary>
    public static class Clock
    {
        /// <summary>
        /// 获取或设置时间提供者，默认为 <see cref="LocalClockProvider"/>
        /// </summary>
        public static IClockProvider Provider { get; set; }

        #region Ctor

        static Clock()
        {
            Provider = IocManager.Instance.Resolve<IClockProvider>();
        }

        #endregion

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
