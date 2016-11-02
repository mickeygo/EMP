namespace DotPlatform.Logger
{
    /// <summary>
    /// 表示日志记录
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 记录测试信息
        /// </summary>
        void Debug();

        /// <summary>
        /// 记录普通信息
        /// </summary>
        void Info();

        /// <summary>
        /// 记录警告信息
        /// </summary>
        void Warn();

        /// <summary>
        /// 记录错误信息
        /// </summary>
        void Error();

        /// <summary>
        /// 记录重大错误信息
        /// </summary>
        void Fatal();
    }
}
