﻿using DotPlatform.Dependency;
using DotPlatform.TestBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WMS.Application.Services;
using WMS.DataTransferObject.Dtos;

namespace WMS.Tests.ApplicationServices.Services
{
    [TestClass]
    public class WarehouseAppService_Tests : UnitTestBase
    {
        [TestMethod]
        public void Should_Get_Warehouse_Test()
        {
            using (var service = IocManager.Instance.Resolve<IWarehouseAppService>())
            {
                var warehouses = service.GetAllWarehouses();
                Assert.IsNotNull(warehouses);
                Assert.IsTrue(warehouses[0].Name == "AKMC01");
            }
        }

        [TestMethod]
        public void Should_Create_Warehouse_Test()
        {
            using (var service = IocManager.Instance.Resolve<IWarehouseAppService>())
            {
                service.CreateWarehouse(new WarehouseDto
                {
                    Name = "AKMC02",
                    DisplayName = "AKMC 02",
                    Description = "AKMC 02 Test",
                    Length = 5,
                    Width = 3,
                    Height = 1
                });
            }
        }
    }
}
