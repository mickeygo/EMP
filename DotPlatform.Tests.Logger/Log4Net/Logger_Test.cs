using log4net;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.Logger.Log4Net
{
    [TestClass]
    public class Logger_Test
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Logger_Test));

        [TestMethod]
        public void Test()
        {
            BasicConfigurator.Configure();

            log.Info("Info");
            log.Debug("Debug");
        }
    }
}
