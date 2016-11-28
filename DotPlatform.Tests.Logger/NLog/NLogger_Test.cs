using NLog;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.Logger.NLog
{
    [TestClass]
    public class NLogger_Test
    {
        ILogger log = LogManager.GetCurrentClassLogger();

        [TestMethod]
        public void LogInfo_Test()
        {
            log.Info("Info");

            log.Debug("Debug");

            log.Trace("Trace");

            log.Error("Error");
        }
    }
}
