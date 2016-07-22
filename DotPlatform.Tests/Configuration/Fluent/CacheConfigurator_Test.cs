using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotPlatform.Configuration.Fluent;

namespace DotPlatform.Tests.Configuration.Fluent
{
    [TestClass]
    public class CacheConfigurator_Test
    {
        [TestMethod]
        public void ShouldGetCacheConfiguration_Test()
        {
            var configruator = new CacheFluentConfigurator();
            var cacheConfig = configruator.GetConfiguration();

            var keys = cacheConfig.CacheElementCollection.GetAllKeys;

            Assert.IsTrue(keys.Count() == 2);
        }
    }
}
