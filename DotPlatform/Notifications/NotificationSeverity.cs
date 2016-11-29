namespace DotPlatform.Notifications
{
    /// <summary>
    /// 通知严重性等级
    /// </summary>
    public enum NotificationSeverity
    {
        /// <summary>
        /// Info.
        /// </summary>
        Info = 0,
        
        /// <summary>
        /// Success.
        /// </summary>
        Success = 1,
        
        /// <summary>
        /// Warn.
        /// </summary>
        Warn = 2,
        
        /// <summary>
        /// Error.
        /// </summary>
        Error = 3,

        /// <summary>
        /// Fatal.
        /// </summary>
        Fatal = 4
    }
}
