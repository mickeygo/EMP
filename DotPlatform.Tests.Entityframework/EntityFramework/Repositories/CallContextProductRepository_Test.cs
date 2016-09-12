using System;
using DotPlatform.Dependency;
using DotPlatform.Domain.Uow;
using DotPlatform.EntityFramework;
using DotPlatform.EntityFramework.Uow;
using DotPlatform.TestBase;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.Tests.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotPlatform.Tests.EntityFramework.Services;

namespace DotPlatform.Tests.Entityframework.Repositories
{
    /// <summary>
    /// 基于 CallContext 的测试
    /// </summary>
    [TestClass]
    public class CallContextProductRepository_Test : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            IocManager.Instance.Register<ICallContextProductRepository, CallContextProductRepository>(IocLifeStyle.Singleton);
            IocManager.Instance.RegisterGeneric(typeof(IDbContextProvider<>), typeof(UnitOfWorkDbContextProvider<>));
            IocManager.Instance.Register<ICurrentUnitOfWorkProvider, CallContextCurrentUnitOfWorkProvider>(IocLifeStyle.Singleton);
            IocManager.Instance.Register<TestEfDbContext>();
            IocManager.Instance.Register<ICallContextProductRepository2, UpdateProductAppService>(IocLifeStyle.Singleton);
            IocManager.Instance.Register<TestEfDbContext2>();

            IocManager.Instance.RegisterWithInterceptor<IProductAppService, ProductAppService_Test>(IocLifeStyle.Singleton, typeof(UnitOfWorkInterceptor));

            IocManager.Instance.Build();
        }

        [TestMethod]
        public void CallContext_UpdateProduct()
        {
            var _callContextProductRepository = IocManager.Instance.Resolve<ICallContextProductRepository>();

            // Error
            //var count = _callContextProductRepository.Count();
            //Assert.IsTrue(count > 0);

            var _unitOfWorkManager = IocManager.Instance.Resolve<IUnitOfWorkManager>();

            using (var uow = _unitOfWorkManager.Begin())
            {
                var pro = _callContextProductRepository.FirstOrDefault(new Guid("85C2B3A5-117B-8BD2-AA78-39D8D7E7B218"));
                pro.Model = "Model_010";

                _callContextProductRepository.Update(pro);

                uow.Complete();
            }
        }

        [TestMethod]
        public void CallContext_UowAttribute_GetProduct()
        {
            var productAppService = IocManager.Instance.Resolve<IProductAppService>();
            var product = productAppService.Get(new Guid("85C2B3A5-117B-8BD2-AA78-39D8D7E7B218"));

            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void CallContext_UowAttribute_AddProduct()
        {
            var product = new Product
            {
                Name = "PN_004",
                Model = "Model_04"
            };

            var productAppService = IocManager.Instance.Resolve<IProductAppService>();

            productAppService.Add(product);
        }

        [TestMethod]
        public void CallContext_UowAttribute_UpdateProduct()
        {
            var productAppService = IocManager.Instance.Resolve<IProductAppService>();
            productAppService.Update(new Guid("85C2B3A5-117B-8BD2-AA78-39D8D7E7B218"));
        }
    }
}
