using System;
using DotPlatform.Runtime.Session;
using DotPlatform.Extensions;

namespace DotPlatform.Timing
{
    /// <summary>
    /// Local 时间提供者
    /// </summary>
    public class LocalClockProvider : IClockProvider
    {
        public DateTime Local
        {
            get { return this.GetLocalDateTime(); }
        }

        public DateTime System
        {
            get { return DateTime.Now; }
        }

        #region Private Methods

        private DateTime GetLocalDateTime()
        {
            var timeDiff = ClaimsSession.Instance.TimeDifference.ToStruct();
            return DateTime.Now.AddHours(timeDiff);
        }

        #endregion
    }
}
