using System;

namespace DotPlatform.Loggers
{
    /// <summary>
    /// 空的日志记录类
    /// </summary>
    public sealed class NullLogger : ILogger
    {
        private static ILogger instance = new NullLogger();

        /// <summary>
        /// 获取<see cref="ILogger"/>实例, 单例模式
        /// </summary>
        public static ILogger Instance
        {
            get { return instance; }
        }

        public void Debug(string message, Exception ex = null)
        {

        }

        public void Info(string message, Exception ex = null)
        {

        }

        public void Warn(string message, Exception ex = null)
        {
            
        }

        public void Error(string message, Exception ex = null)
        {

        }

        public void Fatal(string message, Exception ex = null)
        {

        }
    }
}
