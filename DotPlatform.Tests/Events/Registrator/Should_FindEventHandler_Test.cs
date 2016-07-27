using System.Linq;
using DotPlatform.Dependency;
using DotPlatform.Events.Startup;
using DotPlatform.TestBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotPlatform.TestBase.EventHandlers;

namespace DotPlatform.Tests.Events.Registrator
{
    [TestClass]
    public class Should_FindEventHandler_Test : UnitTestBase
    {
        protected override void PreInitialize()
        {
            var type = typeof(ProductCreatedEventHandler);
        }

        [TestMethod]
        public void FindEventHandler_Test()
        {
            var eventHandlerFinder = IocManager.Instance.Resolve<IEventHandlerFinder>();
            var eventHandlerTypes = eventHandlerFinder.FindAll();
            var count = eventHandlerTypes.Count();

            Assert.IsTrue(count > 0);
        }
    }
}
