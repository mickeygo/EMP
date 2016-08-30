using DotPlatform.RBAC.Domain.Models.Tenants;
using DotPlatform.RBAC.Domain.Models.Users;
using DotPlatform.RBAC.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.SampleRbac.Repositories
{
    [TestClass]
    public class RawRepository_Tests
    {
        [TestMethod]
        public void Repository_Test()
        {
            var dbContext = new RbacEfDbContext();
            var tenant = dbContext.Set<RbacTenant>();
            var user = dbContext.Set<RbacUser>();

            Assert.IsNotNull(tenant);
            Assert.IsNotNull(user);
        }
    }
}
