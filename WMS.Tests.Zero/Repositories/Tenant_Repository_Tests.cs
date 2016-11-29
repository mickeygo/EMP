using DotPlatform.Dependency;
using DotPlatform.TestBase;
using DotPlatform.Zero.Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WMS.Tests.Zero.Repositories
{
    [TestClass]
    public class Tenant_Repository_Tests : UnitTestBase
    {
        protected override void MakeSession(TestIdentity identity)
        {
            identity.TenantId = "70DABE1F-33A4-4F28-9499-D38EDFC57644";
            //identity.UserId = "";
        }

        [TestMethod]
        public void Should_GetTenant_Test()
        {
            using (var service = IocManager.Instance.Resolve<ITenantRepository>())
            {
                var allTenants = service.GetAllList();

                Assert.IsNotNull(allTenants);
                Assert.IsNotNull(allTenants[0].Name == "Local");
            }
        }
    }
}
