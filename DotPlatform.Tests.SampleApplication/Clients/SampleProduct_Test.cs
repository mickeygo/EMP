using DotPlatform.Dependency;
using DotPlatform.TestBase;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.TestBase.Repositores;
using DotPlatform.Tests.SampleApplication.Application;
using DotPlatform.Tests.SampleApplication.EntityFramework;
using DotPlatform.Tests.SampleApplication.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.SampleApplication.Clients
{
    [TestClass]
    public class SampleProduct_Test : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            IocManager.Instance.Register<IProductRepository, SampleProductRepository>();
            IocManager.Instance.Register<IProductAppService, SampleProductAppService>();
            IocManager.Instance.Register<SampleDbContext>(IocLifeStyle.Transient);

            IocManager.Instance.Build();
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
    }
}
