using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.Utils
{
    [TestClass]
    public class Enum_Tests
    {
        [TestMethod]
        public void Shoud_Get_Enum_Hashcode_Test()
        {
            Assert.IsTrue(DotPlatformEnum_Test.Test.GetHashCode() == 0);
            Assert.IsTrue(DotPlatformEnum_Test.Test.GetHashCode() == (int)DotPlatformEnum_Test.Test);
        }

        [TestMethod]
        public void Shoud_Get_Enum_Char_Test()
        {
            Assert.IsTrue((char)DotPlatformEnumChar_Test.AA == 'A');
            Assert.IsTrue((DotPlatformEnumChar_Test)'A' == DotPlatformEnumChar_Test.AA);
        }

        private enum DotPlatformEnum_Test
        {
            Test,
            Test01,
            Test02,
            Test03
        }

        private enum DotPlatformEnumChar_Test
        {
            AA = 'A',
            BB = 'B',
            CC = 'C',
            DD = 'D'
        }
    }
}
