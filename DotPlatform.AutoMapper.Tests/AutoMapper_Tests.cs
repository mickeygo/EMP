using System;
using DotPlatform.TestBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using AutoMapper.Configuration;

namespace DotPlatform.AutoMapper.Tests
{
    [TestClass]
    public class AutoMapper_Tests : UnitTestBase
    {
        [TestMethod]
        public void PersonDto()
        {
            var person = new DtoPerson_Test
            {
                Name = "XiaoMing",
                Age = 12,
                Birthday = DateTime.Now.AddYears(-12),
                Married = false
            };

            var person2 = new DtoPerson2_Test
            {
                Name = "XiaoFang",
                Age = 12,
                Birthday = DateTime.Now.AddYears(-12),
                Married = false
            };

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap(typeof(DtoPerson_Test), typeof(DtoPersonDesitination_Test));
            //    cfg.CreateMap(typeof(DtoPerson2_Test), typeof(DtoPersonDesitination2_Test));
            //});

            //var mapperConfig = new MapperConfigurationExpression();
            //mapperConfig.CreateMap(typeof(DtoPerson_Test), typeof(DtoPersonDesitination_Test));
            //mapperConfig.CreateMap(typeof(DtoPerson2_Test), typeof(DtoPersonDesitination2_Test));

            //Mapper.Initialize(mapperConfig);

            var personDest = Mapper.Map<DtoPersonDesitination_Test>(person);
            //var personDest2 = Mapper.Map<DtoPersonDesitination2_Test>(person2);

            Assert.IsNull(personDest, personDest.Name);
            //Assert.IsNull(personDest2, personDest2.Name);
        }
    }
}
