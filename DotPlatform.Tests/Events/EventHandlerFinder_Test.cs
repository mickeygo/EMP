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
        public void Should_Find_OK()
        {
            var type = typeof(ProductCreatedEventHandler);

            Assert.IsTrue(type.IsClass
                && !type.IsAbstract
                && type.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEventHandler<>)));

            Assert.IsTrue(type.GetInterfaces().First().GetGenericArguments().First().Equals(typeof(ProductCreatedEvent)));
        }

        [TestMethod]
        public void Should_Convert_OK()
        {
            var productEventHandler = new ProductCreatedEventHandler(null);

            Assert.IsTrue(productEventHandler is IEventHandler<ProductCreatedEvent>);

            Assert.IsTrue(productEventHandler is IEventHandler<IEvent>);
        }
    }
}
