using System;
using System.Collections.Generic;
using DotPlatform.Dependency;
using DotPlatform.Domain.Uow;
using DotPlatform.TestBase;
using DotPlatform.TestBase.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.EntityFramework.Repositories
{
    [TestClass]
    public class OrderRepository_Test : UnitTestBase
    {
        [TestMethod]
        public void GetAllOrders()
        {
            var repository = new OrderRepository();

            var orders = repository.GetAllList();

            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count == 0);
        }

        [TestMethod]
        public void AddOrder()
        {
            var order = new Order
            {
                 OrderNo = "PO_0004"
            };

            var uowManager = IocManager.Instance.Resolve<IUnitOfWorkManager>();

            using (var uow = uowManager.Begin())
            {
                var repository = new OrderRepository();

                repository.Add(order);

                //throw new System.Exception("Error");

                uow.Complete();
            }
        }

        [TestMethod]
        public void AddOrderLine()
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                OrderNo = "PO_0004"
            };

            order.OrderLines = new List<OrderLine> {
                new OrderLine {
                    Id = Guid.NewGuid(),
                    OrderId = order.Id,
                    ProductId = new Guid("85C2B3A5-117B-8BD2-AA78-39D8D7E7B218")
                }
            };

            var uowManager = IocManager.Instance.Resolve<IUnitOfWorkManager>();

            using (var uow = uowManager.Begin())
            {
                var repository = new OrderRepository();

                repository.Add(order);
                repository.Context.SaveChanges();

                uow.Complete();
            }
        }

        [TestMethod]
        public void GetOrderLine()
        {
            var uowManager = IocManager.Instance.Resolve<IUnitOfWorkManager>();

            var repository = new OrderRepository();
            var order = repository.Get(new Guid("7C33B023-B98E-44AE-BFBC-64674D811C2A"));
            var orderLines = order.OrderLines;

            Assert.IsNotNull(orderLines);
        }

        [TestMethod]
        public void ModifiOrder()
        {
            var uowManager = IocManager.Instance.Resolve<IUnitOfWorkManager>();

            var repository = new OrderRepository();
            var order = repository.Get(new Guid("7C33B023-B98E-44AE-BFBC-64674D811C2A"));
            //order.OrderNo = "PO_0004";
            order.OrderLines[0].Qty = 6;
            repository.Update(order);

            repository.Context.SaveChanges();
        }

        [TestMethod]
        public void RemoveOrderLine()
        {
            var uowManager = IocManager.Instance.Resolve<IUnitOfWorkManager>();

            var repository = new OrderRepository();
            var order = repository.Get(new Guid("7C33B023-B98E-44AE-BFBC-64674D811C2A"));
            order.OrderLines.Clear();
            repository.Update(order);

            repository.Context.SaveChanges();
        }
    }
}
