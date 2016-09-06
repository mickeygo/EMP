namespace DotPlatform.Logger
{
    /// <summary>
    /// 空的日志记录类
    /// </summary>
    public sealed class NullLogger : ILogger
    {
        private static NullLogger instance = new NullLogger();

        /// <summary>
        /// 获取<see cref="ILogger"/>实例, 单例模式
        /// </summary>
        public static ILogger Instance
        {
            get { return instance; }
        }

        public void Debug()
        {

        }

        public void Info()
        {

        }

        public void Warn()
        {
            
        }

        public void Error()
        {

        }

        public void Fatal()
        {

        }
    }
}
