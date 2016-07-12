using DotPlatform.Dependency;
using DotPlatform.Domain.Uow;
using DotPlatform.TestBase;
using DotPlatform.TestBase.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.EntityFramework.Repositories
{
    [TestClass]
    public class ProductRepository_Test : UnitTestBase
    {
        [TestMethod]
        public void GetProduct()
        {
            var repository = new ProductRepository();
            var products = repository.GetAllList();

            Assert.IsNotNull(products);
        }

        [TestMethod]
        public void AddProduct()
        {
            var product = new Product
            {
                Name = "PN_001",
                Model = "Nodel_01"
            };

            var uowManager = IocManager.Instance.Resolve<IUnitOfWorkManager>();

            using (var uow = uowManager.Begin())
            {
                var repository = new ProductRepository();

                repository.Add(product);
                repository.Context.SaveChanges();

                uow.Complete();
            }
        }
    }
}
