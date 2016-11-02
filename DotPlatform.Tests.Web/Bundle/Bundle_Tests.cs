using DotPlatform.Web.Bundle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.Web.Bundle
{
    [TestClass]
    public class Bundle_Tests
    {
        [TestMethod]
        public void Should_ReloveConfigFile_Test()
        {
            var manager = new BundleManager();
            var data = manager.Resolve();

            Assert.IsNotNull(data);
        }
    }
}
