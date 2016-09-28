using System;
using System.Collections.Generic;
using System.IO;
using DotPlatform.Plugin.IO.Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.Plugin.IO.Excel
{
    [TestClass]
    public class Excel_Export_Import_Tests
    {
        private List<ExcelClass> _excelDatas;

        [TestInitialize]
        public void Init()
        {
            _excelDatas = new List<ExcelClass>
            {
                new ExcelClass { Col01 = "101", Col02 = "102", Col03 = 1, Col04 = 11, Col05 = DateTime.Now },
                new ExcelClass { Col01 = "201", Col02 = "202", Col03 = 2, Col04 = 21, Col05 = DateTime.Now },
                new ExcelClass { Col01 = "301", Col02 = "302", Col03 = 3, Col04 = 31, Col05 = DateTime.Now },
                new ExcelClass { Col01 = "401", Col02 = "402", Col03 = 4, Col04 = 41, Col05 = DateTime.Now },
                new ExcelClass { Col01 = "501", Col02 = "502", Col03 = 5, Col04 = 51, Col05 = DateTime.Now }
            };
        }

        [TestMethod]
        public void Should_Export_Test()
        {
            FileStream fileStream = null;
            try
            {
                fileStream = new FileInfo(@"D:\\My_Excel_Test.xlsx").Create();
                var excel = ExcelFactory.CreateCollectionWriter();
                excel.Wirte("My_Excel_Test", _excelDatas);
                excel.Save(fileStream);
            }
            finally
            {
                fileStream?.Dispose();
            }
        }

        [TestMethod]
        public void Should_Import_Test()
        {
            var reader = ExcelFactory.CreateReader(@"D:\\My_Excel_Test.xlsx");
            var datas = reader.Read<ExcelClass>(0);

            Assert.IsNotNull(datas);
            Assert.IsTrue(datas.Count == 5);
            Assert.IsTrue(datas[2].Col03 == 3);
        }

        class ExcelClass
        {
            public string Col01 { get; set; }

            public string Col02 { get; set; }

            public int Col03 { get; set; }

            public int? Col04 { get; set; }

            public DateTime Col05 { get; set; }

            public DateTime? Col06 { get; set; }

            public bool Col07 { get; set; }

            public bool? Col08 { get; set; }

            public double Col09 { get; set; }

            public double? Col10 { get; set; }
        }
    }
}
