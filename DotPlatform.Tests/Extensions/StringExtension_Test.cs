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
    }
}
