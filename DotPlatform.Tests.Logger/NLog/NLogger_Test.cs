using NLog;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.Logger.NLog
{
    [TestClass]
    public class NLogger_Test
    {
        public static ILogger log = LogManager.GetCurrentClassLogger();

        [TestMethod]
        public void LogInfo_Test()
        {
            log.Info("Info");

            log.Error("Error");

            try
            {
                throw new Exception("Throw Error");
            }
            catch (Exception ex)
            {
                log.Error("Error", new[] { ex });
            }  
        }
    }
}
