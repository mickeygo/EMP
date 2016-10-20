using DotPlatform.Dependency;
using DotPlatform.TestBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WMS.Domain.QueryRepositories;

namespace WMS.Tests.Repository.Inbounds
{
    [TestClass]
    public class StockInRepository_Tests : UnitTestBase
    {
        [TestMethod]
        public void Should_Get_StockIn_Test()
        {
            using (var service = IocManager.Instance.Resolve<IStockInQueryRepository>())
            {
                var warehouse = service.Get("201525-L-0169");

                Assert.IsNotNull(warehouse);
                Assert.IsTrue(warehouse.PartNumber == "PCA-6010VG-CTA1E");
                Assert.IsNotNull(warehouse.StockInLines);
                Assert.IsTrue(warehouse.StockInLines.Count == 3);
            }
        }
    }
}

