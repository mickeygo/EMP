namespace DotPlatform.Loggers
{
    /// <summary>
    /// 日志严重性级别
    /// </summary>
    public enum LogSeverity
    {
        /// <summary>
        /// Begin method X, end method X etc
        /// </summary>
        Trace,

        /// <summary>
        /// 调试
        /// Executed queries, user authenticated, session expired
        /// </summary>
        Debug,

        /// <summary>
        /// 消息
        /// Normal behavior like mail sent, user updated profile etc.
        /// </summary>
        Info,

        /// <summary>
        /// 警告
        /// incorrect behavior but the application can continue
        /// </summary>
        Warn,

        /// <summary>
        /// 错误
        /// For example application crashes / exceptions.
        /// </summary>
        Error,

        /// <summary>
        /// 严重错误
        /// Highest level: important stuff down
        /// </summary>
        Fatal
    }
}
