using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using DotPlatform.TestBase;
using DotPlatform.Tests.AutoMapper.Dto;
using System.Collections.Generic;
using DotPlatform.AutoMapper;

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

            var persons = new List<Person_Test>
            {
                new Person_Test
                {
                    Name = "XiaoMing",
                    Age = 12,
                    Birthday = DateTime.Now.AddYears(-12),
                    Married = false
                },
                new Person_Test
                {
                    Name = "XiaoFang",
                    Age = 12,
                    Birthday = DateTime.Now.AddYears(-12),
                    Married = false
                },
            };

            var personsDest = Mapper.Map<List<PersonDesitination_Test>>(persons);
            Assert.IsNotNull(personsDest);
            Assert.IsTrue(personsDest.Count == 2);
            Assert.IsTrue(personsDest[1].Name == "XiaoFang");


            var personsDestList = persons.MapTo<PersonDesitination_Test>();
            Assert.IsNotNull(personsDestList);
            Assert.IsTrue(personsDestList.Count == 2);
            Assert.IsTrue(personsDestList[1].Name == "XiaoFang");
        }
    }
}
