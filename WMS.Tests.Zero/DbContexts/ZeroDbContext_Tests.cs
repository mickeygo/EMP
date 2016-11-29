using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotPlatform.Zero.Domain.Models.Core;

namespace WMS.Tests.Zero.DbContexts
{
    [TestClass]
    public class ZeroDbContext_Tests
    {
        [TestMethod]
        public void Should_Get_Tenant_Test()
        {
            using (var context = new ZeroDbContextTest())
            {
                var tenants = context.Tenants.ToList();

                Assert.IsNotNull(tenants);
                Assert.IsTrue(tenants[0].Name == "Local");
            }
        }

        [TestMethod]
        public void Should_Get_RolesOfUser_Test()
        {
            using (var context = new ZeroDbContextTest())
            {
                var users = context.Users.ToList();

                Assert.IsNotNull(users);
                Assert.IsTrue(users[0].UserName == "gang.yang@advantech.com.cn");
                Assert.IsNotNull(users[0].Roles);
                Assert.IsTrue(users[0].Roles.Count > 0); // function error
            }
        }

        [TestMethod]
        public void Should_Create_RoleRelationOfUser_Test()
        {
            var role = new Role(new Guid("70DABE1F-33A4-4F28-9499-D38EDFC57644"), "Admin", "Admin Test");
            role.Id = new Guid("FAE7FEDA-6172-447D-B353-943C712D6431");
            //role.Id = Guid.NewGuid();
            role.CreatorUserId = new Guid("9165331B-191B-4533-A677-E8BB724B9E18");
            role.CreationTime = DateTime.Now;

            using (var context = new ZeroDbContextTest())
            {
                var user = context.Users.First();
                //var role = context.Roles.First(r => r.Id == new Guid("FAE7FEDA-6172-447D-B353-943C712D6431"));
                //role.Description = "Admin Test2";

                context.Roles.Attach(role);

                user.Roles.Add(role);

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void Should_Remove_RoleRelationOfUser_Test()
        {
            var role = new Role(new Guid("70DABE1F-33A4-4F28-9499-D38EDFC57644"), "Admin", "Admin Test");
            role.Id = new Guid("FAE7FEDA-6172-447D-B353-943C712D6439");
            role.CreatorUserId = new Guid("9165331B-191B-4533-A677-E8BB724B9E18");
            role.CreationTime = DateTime.Now;

            using (var context = new ZeroDbContextTest())
            {
                //var role = context.Roles.First(r => r.Id == new Guid("100095C3-0C8A-4B97-948F-06EF97D48900"));
                //context.Roles.Remove(role);

                var user = context.Users.First();
                user.Roles.Remove(role);

                context.SaveChanges();
            }
        }
    }
}
