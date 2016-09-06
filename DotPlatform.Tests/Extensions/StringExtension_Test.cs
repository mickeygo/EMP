using System.Linq;
using DotPlatform.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.Extensions
{
    [TestClass]
    public class StringExtension_Test
    {
        [TestMethod]
        public void StartsIn_Test()
        {
            Assert.IsTrue("abc".StartsIn("ab", "b", "c"));
        }

        [TestMethod]
        public void EndsIn_Test()
        {
            Assert.IsTrue("abc".EndsIn("bc", "c"));
        }

        [TestMethod]
        public void Should_Collection_Not_In()
        {
            var stringCollection = new[] { "mscorlib.a", "System.b", "DotPlatform.c" };
            var result = stringCollection.Where(s => !s.StartsIn("mscorlib", "Microsoft", "System"));

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }
    }
}
