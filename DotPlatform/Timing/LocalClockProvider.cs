using System;

namespace DotPlatform.Timing
{
    /// <summary>
    /// Local 时间提供者
    /// </summary>
    public class LocalClockProvider : IClockProvider
    {
        public DateTime Local
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime System
        {
            get { return DateTime.Now; }
        }
    }
}
