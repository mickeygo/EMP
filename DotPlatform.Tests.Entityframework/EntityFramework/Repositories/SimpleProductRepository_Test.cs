using DotPlatform.Dependency;
using DotPlatform.Domain.Uow;
using DotPlatform.EntityFramework;
using DotPlatform.TestBase;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.Tests.Entityframework.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.EntityFramework.Repositories
{
    [TestClass]
    public class SimpleProductRepository_Test : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            IocManager.Instance.Register<ISimpleProductRepository, SimpleProductRepository>();
            IocManager.Instance.RegisterGeneric(typeof(IDbContextProvider<>), typeof(UnitOfWorkDbContextProvider<>), IocLifeStyle.Transient);
            IocManager.Instance.Register<TestEfDbContext>(IocLifeStyle.Transient);

            IocManager.Instance.Build();
        }

        [TestMethod]
        public void GetProduct()
        {
            var _simpleProductRepository = IocManager.Instance.Resolve<ISimpleProductRepository>();
            var products = _simpleProductRepository.GetAllList();

            Assert.IsNotNull(products);
        }

        [TestMethod]
        public void Simple_AddProduct()
        {
            var product = new Product
            {
                Name = "PN_002",
                Model = "Nodel_02"
            };

            var _simpleProductRepository = IocManager.Instance.Resolve<ISimpleProductRepository>();
            var _unitOfWorkManager = IocManager.Instance.Resolve<IUnitOfWorkManager>();
            using (var uow = _unitOfWorkManager.Begin())
            {
                _simpleProductRepository.Add(product);

                uow.Complete();
            }
        }
    }
}
