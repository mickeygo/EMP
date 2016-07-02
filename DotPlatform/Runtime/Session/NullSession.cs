using System;

namespace DotPlatform.Runtime.Session
{
    /// <summary>
    /// 空的 Session 实例
    /// </summary>
    public sealed class NullSession : IOwnerSession
    {
        private readonly static NullSession _instance = new NullSession();

        private NullSession()
        {

        }

        /// <summary>
        /// 获取 Session 实例
        /// </summary>
        public static IOwnerSession Instance
        {
            get { return _instance; }
        }

        public Guid? TenantId { get; private set; }

        public Guid? UserId { get; private set; }

        public int? TimeDifference { get; private set; }
    }
}
