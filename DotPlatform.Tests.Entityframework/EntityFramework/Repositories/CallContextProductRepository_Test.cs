using DotPlatform.Dependency;
using DotPlatform.Domain.Uow;
using DotPlatform.EntityFramework;
using DotPlatform.TestBase;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.Tests.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            IocManager.Instance.Register<ICallContextProductRepository, CallContextProductRepository>();
            IocManager.Instance.RegisterGeneric(typeof(IDbContextProvider<>), typeof(UnitOfWorkDbContextProvider<>), IocLifeStyle.Transient);
            IocManager.Instance.Register<ICurrentUnitOfWorkProvider, CallContextCurrentUnitOfWorkProvider>();
            IocManager.Instance.Register<TestEfDbContext>(IocLifeStyle.Transient);

            IocManager.Instance.Build();
        }

        [TestMethod]
        public void CallContext_AddProduct()
        {
            var product = new Product
            {
                Name = "PN_003",
                Model = "Nodel_03"
            };

            var _callContextProductRepository = IocManager.Instance.Resolve<ICallContextProductRepository>();
            var _unitOfWorkManager = IocManager.Instance.Resolve<IUnitOfWorkManager>();

            using (var uow = _unitOfWorkManager.Begin())
            {
                _callContextProductRepository.Add(product);

                uow.Complete();
            }
        }
    }
}
