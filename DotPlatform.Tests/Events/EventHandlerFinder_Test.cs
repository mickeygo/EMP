using System.Linq;
using DotPlatform.Events;
using DotPlatform.TestBase.EventHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotPlatform.TestBase.Events;

namespace DotPlatform.Tests.Events
{
    [TestClass]
    public class EventHandlerFinder_Test
    {
        [TestMethod]
        public void Should_FindOK()
        {
            var type = typeof(ProductCreatedEventHandler);

            Assert.IsTrue(type.IsClass
                && !type.IsAbstract
                && type.GetInterfaces().Any(t => t.GetGenericTypeDefinition() == typeof(IEventHandler<>)));

            Assert.IsTrue(type.GetInterfaces().First().GetGenericArguments().First().Equals(typeof(ProductCreatedEvent)));
        }
    }
}
