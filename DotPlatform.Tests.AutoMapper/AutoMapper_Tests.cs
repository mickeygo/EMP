using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using DotPlatform.TestBase;
using DotPlatform.Tests.AutoMapper.Dto;

namespace DotPlatform.Tests.AutoMapper
{
    [TestClass]
    public class AutoMapper_Tests : UnitTestBase
    {
        [TestMethod]
        public void PersonDto()
        {
            var person = new Person_Test
            {
                Name = "XiaoMing",
                Age = 12,
                Birthday = DateTime.Now.AddYears(-12),
                Married = false
            };

            var person2 = new Person2_Test
            {
                Name = "XiaoFang",
                Age = 12,
                Birthday = DateTime.Now.AddYears(-12),
                Married = false
            };

            var personDest = Mapper.Map<PersonDesitination_Test>(person);
            var personDest2 = Mapper.Map<PersonDesitination_Test>(person);

            Assert.IsNotNull(personDest);
            Assert.IsNotNull(personDest2);
        }
    }
}
