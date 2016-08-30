using DotPlatform.Dependency;
using DotPlatform.RBAC.Domain.Repositories;
using DotPlatform.RBAC.Repository;
using DotPlatform.RBAC.Repository.Repositories;
using DotPlatform.TestBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.SampleRbac.Repositories
{
    [TestClass]
    public class UserRepository_Tests : UnitTestBase
    {
        protected override void PostInitialize()
        {
            IocManager.Instance.Register<IUserRepository, UserRepository>();
            IocManager.Instance.Register<RbacEfDbContext>(IocLifeStyle.Transient);

            IocManager.Instance.Build();
        }

        [TestMethod]
        public void Should_GetUser_Test()
        {
            var userRepository = IocManager.Instance.Resolve<IRoleRepository>();
            Assert.IsNotNull(userRepository);
        }
    }
}
