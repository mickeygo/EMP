using System;

namespace DotPlatform.RealTime
{
    /// <summary>
    /// <see cref="IOnlineClientManager"/>扩展方法
    /// </summary>
    public static class OnlineClientManagerExtensions
    {
        /// <summary>
        /// 指定的用户是否在线
        /// </summary>
        /// <param name="onlineClientManager">The online client manager.</param>
        /// <param name="userId">用户 id.</param>
        public static bool IsOnline(IOnlineClientManager onlineClientManager, Guid userId)
        {
            return onlineClientManager.GetByUserIdOrNull(userId) != null;
        }
    }
}