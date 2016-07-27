using DotPlatform.Dependency;
using DotPlatform.Domain.Uow;
using DotPlatform.TestBase;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.TestBase.EventHandlers;
using DotPlatform.TestBase.Events;
using DotPlatform.TestBase.Repositores;
using DotPlatform.Tests.SampleApplication.EntityFramework;
using DotPlatform.Tests.SampleApplication.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.SampleApplication.EventHandlers
{
    [TestClass]
    public class ProductCreatedEventHandler_Test : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            IocManager.Instance.Register<IProductRepository, SampleProductRepository>();
            IocManager.Instance.RegisterWithInterceptor(typeof(ProductCreatedEventHandler), IocLifeStyle.Transient, typeof(UnitOfWorkInterceptor));
            IocManager.Instance.Register<SampleDbContext>(IocLifeStyle.Transient);

            IocManager.Instance.Build();
        }

        [TestMethod]
        public void Should_Handle_Test()
        {
            var product = new Product
            {
                Name = "PN_Name",
                Model = "PN_Model"
            };

            var eventHandler = IocManager.Instance.Resolve<ProductCreatedEventHandler>();
            eventHandler.Handle(new ProductCreatedEvent(product));
        }
    }
}
