using DotPlatform.Extensions;
using DotPlatform.TestBase.EventHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.Reflection.Dynamic
{
    [TestClass]
    public class RelectionDynamic_Test
    {
        [TestMethod]
        public void Should_Relect_Dynamic_Test()
        {
            var productEventHandler = new ProductCreatedEventHandler(null);

            dynamic obj = productEventHandler.AsDynamic();

            obj.Handle(null);
        }
    }
}
