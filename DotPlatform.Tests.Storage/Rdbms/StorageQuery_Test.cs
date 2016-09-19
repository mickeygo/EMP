using DotPlatform.Dependency;
using DotPlatform.Storage.Rdbms;
using DotPlatform.TestBase;
using DotPlatform.TestBase.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.Storage.Rdbms
{
    [TestClass]
    public class StorageQuery_Test : UnitTestBase
    {
        protected override void PreInitialize()
        {
            IocManager.Instance.Register<MyTestRepository>();
        }

        [TestMethod]
        public void QueryMulit_Test()
        {
            var sqlQuery = " SELECT ";
            sqlQuery += "           PO.OrderId ,OrderNo,PO.IsDeleted,PO.CreatorUserId,PO.CreationTime ";
            sqlQuery += "           ,OrderLineId AS Id ,OrderLine.OrderId,OrderLine.ProductId,Qty,OrderLine.CreatorUserId,OrderLine.CreationTime ";
            sqlQuery += "           ,Product.ProductId AS Id ,Name, Model, Product.IsDeleted, Product.CreatorUserId, Product.CreationTime ";
            sqlQuery += "   FROM	dbo.PO ";
            sqlQuery += "           INNER JOIN dbo.OrderLine ON OrderLine.OrderId = PO.OrderId ";
            sqlQuery += "           INNER JOIN dbo.Product ON Product.ProductId = OrderLine.ProductId ";

            //var orderLookup = new Order();
            var repository = IocManager.Instance.Resolve<MyTestRepository>();

            var orderResult = repository.Select<Order, OrderLine, Product, Product>(sqlQuery, 
                (order, orderLine, product) => 
                {
                    return product;
                });

            Assert.IsNotNull(orderResult);
        }
    }
}
