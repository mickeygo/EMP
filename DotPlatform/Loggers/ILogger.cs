using System;

namespace DotPlatform.Loggers
{
    /// <summary>
    /// 表示日志记录
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 记录调试程序信息
        /// </summary>
        void Debug(string message, Exception ex = null);

        /// <summary>
        /// 记录信息类型的消息
        /// </summary>
        void Info(string message, Exception ex = null);

        /// <summary>
        /// 记录警告信息
        /// </summary>
        void Warn(string message, Exception ex = null);

        /// <summary>
        /// 记录错误信息
        /// </summary>
        void Error(string message, Exception ex = null);

        /// <summary>
        /// 记录致命异常信息
        /// </summary>
        void Fatal(string message, Exception ex = null);
    }
}
