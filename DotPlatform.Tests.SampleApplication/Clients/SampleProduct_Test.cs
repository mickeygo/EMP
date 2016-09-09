using DotPlatform.Dependency;
using DotPlatform.TestBase;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.TestBase.Repositores;
using DotPlatform.TestBase.Repositores.Query;
using DotPlatform.Tests.SampleApplication.Application;
using DotPlatform.Tests.SampleApplication.EntityFramework;
using DotPlatform.Tests.SampleApplication.Repositories;
using DotPlatform.Tests.SampleApplication.Repositories.Query;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.SampleApplication.Clients
{
    [TestClass]
    public class SampleProduct_Test : UnitTestBase
    {
        protected override void PostInitialize()
        {
            IocManager.Instance.Register<IProductQueryRepository, SampleProductQueryRepository>();
            IocManager.Instance.Register<IProductRepository, SampleProductRepository>();
            IocManager.Instance.Register<IProductAppService, SampleProductAppService>();
            IocManager.Instance.Register<SampleDbContext>(IocLifeStyle.Transient);

            IocManager.Instance.Build();
        }

        [TestMethod]
        public void Should_GetProduct_Test()
        {
            using (var _productAppService = IocManager.Instance.Resolve<IProductAppService>())
            {
                var product = _productAppService.Get(new System.Guid("85C2B3A5-117B-8BD2-AA78-39D8D7E7B218"));

                Assert.IsNotNull(product);
                Assert.IsTrue(product.Name == "PN_001");
            }
        }

        [TestMethod]
        public void Should_CreateProduct_Test()
        {
            var product = new Product
            {
                Name = "PN_Name",
                Model = "PN_Model"
            };

            var _productAppService = IocManager.Instance.Resolve<IProductAppService>();

            _productAppService.Create(product);
        }

        [TestMethod]
        public void Should_UpdateProduct_Test()
        {
            var productId = new System.Guid("85C2B3A5-117B-8BD2-AA78-39D8D7E7B218");
            var model = "Model_01";

            using (var _productAppService = IocManager.Instance.Resolve<IProductAppService>())
            {
                var product = _productAppService.Get(productId);
                product.Model = model;

                _productAppService.Update(product);

                var productNew = _productAppService.Get(productId);
                Assert.IsTrue(productNew.Model == model);
            }
        }
    }
}
