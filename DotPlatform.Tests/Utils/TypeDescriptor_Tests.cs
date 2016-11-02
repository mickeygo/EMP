using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.Utils
{
    [TestClass]
    public class TypeDescriptor_Tests
    {
        [TestMethod]
        public void Should_Get_ClassAttribute()
        {
            var attributes = TypeDescriptor.GetAttributes(typeof(TypeDescriptorTest));

            Assert.IsNotNull(attributes);
            Assert.IsTrue(attributes.Count == 1);
            Assert.IsTrue(attributes[0].GetType() == typeof(MyTypeDescriptorTestAttribute));
        }

        [TestMethod]
        public void Should_Get_PropertyAttribute()
        {
            var propertyDesc = TypeDescriptor.GetProperties(typeof(TypeDescriptorTest)).Find("Test", true);
            var attributes = propertyDesc.Attributes;

            Assert.IsNotNull(attributes);
            Assert.IsTrue(attributes[typeof(MyTypeDescriptorTestAttribute)] != null);
        }
    }

    [MyTypeDescriptorTest]
    class TypeDescriptorTest
    {
        [MyTypeDescriptorTest]
        public string Test { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    class MyTypeDescriptorTestAttribute : Attribute
    {

    }
}
