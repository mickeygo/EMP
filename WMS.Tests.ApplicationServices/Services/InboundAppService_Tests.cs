using DotPlatform.Dependency;
using DotPlatform.TestBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WMS.Application.Services;
using WMS.DataTransferObject.Dtos;

namespace WMS.Tests.ApplicationServices.Services
{
    [TestClass]
    public class InboundAppService_Tests : UnitTestBase
    {
        [TestMethod]
        public void Should_Create_StockIn_Test()
        {
            var model = new StockInDto
            {
                 DocNo = "201525-L-0169",
                 Plant = "CKB4",
                 WipNo = "KEF2218PA",
                 PartNumber = "PCA-6010VG-CTA1E",
                 Quantity = 3,
                 DestPlant = "CKH2",
                 DestLocation = "0000",
                 Remark = "Test",
                 Applicant = "gang.yang@advantech.com.cn",
                 StockInLines = new System.Collections.Generic.List<StockInLineDto> {
                     new StockInLineDto { Barcode = "KSA1985831", CartonNo = "CPS1610111723" },
                     new StockInLineDto { Barcode = "KSA1985826", CartonNo = "CPS1610111758" },
                     new StockInLineDto { Barcode = "KSA1985806", CartonNo = "CPS1610111796" }
                 }
            };

            using (var service = IocManager.Instance.Resolve<IInboundAppService>())
            {
                service.CreateStockIn(model);
            }
        }
    }
}
