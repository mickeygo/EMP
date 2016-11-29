using System;
using DotPlatform.Loggers;
using NLogging = NLog;

namespace DotPlatform.Logger.NLog
{
    /// <summary>
    /// 基于 NLog 组件的系统日志记录者
    /// </summary>
    public class NLogger : ILogger
    {
        private NLogging.ILogger logger = NLogging.LogManager.GetCurrentClassLogger();

        public void Debug(string message, Exception ex = null)
        {
            if (ex == null)
                logger.Debug(message);
            else
                logger.Debug(ex, message);
        }

        public void Info(string message, Exception ex = null)
        {
            if (ex == null)
                logger.Info(message);
            else
                logger.Info(ex, message);
        }

        public void Warn(string message, Exception ex = null)
        {
            if (ex == null)
                logger.Warn(message);
            else
                logger.Warn(ex, message);
        }

        public void Error(string message, Exception ex = null)
        {
            if (ex == null)
                logger.Error(message);
            else
                logger.Error(ex, message);
        }

        public void Fatal(string message, Exception ex = null)
        {
            if (ex == null)
                logger.Fatal(message);
            else
                logger.Fatal(ex, message);
        }
    }
}
