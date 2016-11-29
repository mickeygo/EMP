using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.Utils
{
    [TestClass]
    public class GenericType_Tests
    {
        [TestMethod]
        public void Shoud_IsGenericType_Test()
        {
            Assert.IsTrue(Array.Exists(typeof(GenericTypeTest<>).GetInterfaces(), t => t.GetGenericTypeDefinition() == typeof(IGenericTypeTest<>)));

            Assert.IsTrue(typeof(GenericTypeTest<string>) == typeof(GenericTypeTest<string>));
            Assert.IsTrue(typeof(GenericTypeTest<>) == typeof(GenericTypeTest<>));

            // Assert.IsTrue(typeof(IGenericTypeTest<>).IsAssignableFrom(typeof(GenericTypeTest<>))); // always false
        }
    }

    interface IGenericTypeTest<T>
    {
    }


    class GenericTypeTest<T> : IGenericTypeTest<T>
    {
    }
}
