using System;

namespace DotPlatform.Timing
{
    /// <summary>
    /// 表示实现此接口的类为时间的提供者
    /// </summary>
    public interface IClockProvider
    {
        /// <summary>
        /// 系统当前时间
        /// </summary>
        DateTime System { get; }

        /// <summary>
        /// 在当前区域的当前时间
        /// </summary>
        DateTime Local { get; }
    }
}
