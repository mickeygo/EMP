using System;
using System.Linq;
using DotPlatform.Dependency;
using DotPlatform.TestBase;
using DotPlatform.Zero.Domain.Models.Core;
using DotPlatform.Zero.Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WMS.Tests.Zero.Repositories
{
    [TestClass]
    public class UserRole_Repository_Tests : UnitTestBase
    {
        protected override void MakeSession(TestIdentity identity)
        {
            identity.TenantId = "70DABE1F-33A4-4F28-9499-D38EDFC57644";
            identity.UserId = "9165331B-191B-4533-A677-E8BB724B9E18";
        }

        [TestMethod]
        public void Should_GetUser_Test()
        {
            using (var service = IocManager.Instance.Resolve<IUserRepository>())
            {
                var allUsers = service.GetAllList();

                Assert.IsNotNull(allUsers);
                Assert.IsNotNull(allUsers[0].UserName == "gang.yang@advantech.com.cn");
            }
        }

        [TestMethod]
        public void Should_GetRolesOfUser_Test()
        {
            using (var service = IocManager.Instance.Resolve<IUserRepository>())
            {
                var allUsers = service.GetAllList();

                var roles = allUsers[0].Roles.ToList();

                Assert.IsNotNull(allUsers);
                Assert.IsNotNull(allUsers[0].Roles);
                Assert.IsNotNull(allUsers[0].Roles.ToList().First().Name == "Admin");
            }
        }

        [TestMethod]
        public void Should_UpdateUser_Test()
        {
            using (var service = IocManager.Instance.Resolve<IUserRepository>())
            {
                var user = service.Get(new Guid("9165331B-191B-4533-A677-E8BB724B9E18"));
                user.UpdatePassword("123qwe");
                service.Update(user);
            }
        }

        [TestMethod]
        public void Should_CreateRoleRelationOfUser_Test()
        {
            Role role = null;
            using (var service = IocManager.Instance.Resolve<IRoleRepository>())
            {
                role = service.Get(new Guid("E3246743-7F05-43B3-9142-D214B648B830"));
            }

            using (var service = IocManager.Instance.Resolve<IUserRepository>())
            {
                var user = service.Get(new Guid("9165331B-191B-4533-A677-E8BB724B9E18"));
                user.AttachRole(role);
                service.Update(user);
            }
        }

        [TestMethod]
        public void Should_RemoveRoleOfUser_Test()
        {
            using (var service = IocManager.Instance.Resolve<IUserRepository>())
            {
                var user = service.Get(new Guid("9165331B-191B-4533-A677-E8BB724B9E18"));
                var role = user.Roles.FirstOrDefault();
                user.Roles.Remove(role);
                service.Update(user);
            }
        }

        [TestMethod]
        public void Should_GetRole_Test()
        {
            using (var service = IocManager.Instance.Resolve<IRoleRepository>())
            {
                var allRoles = service.GetAllList();

                Assert.IsNotNull(allRoles);
                Assert.IsNotNull(allRoles[0].Name == "Admin");
            }
        }

        [TestMethod]
        public void Should_GetUsersOfRole_Test()
        {
            using (var service = IocManager.Instance.Resolve<IRoleRepository>())
            {
                var allRoles = service.GetAllList();

                var users = allRoles[0].Users.ToList();

                Assert.IsNotNull(allRoles);
                Assert.IsTrue(users.Count > 0);
            }
        }

        [TestMethod]
        public void Should_AttachRole_Test()
        {
            Role role = null;
            using (var service = IocManager.Instance.Resolve<IRoleRepository>())
            {
                role = service.GetAllList().FirstOrDefault();
            }

            //using (var roleService = IocManager.Instance.Resolve<IRoleRepository<Role>>())
            using (var userService = IocManager.Instance.Resolve<IUserRepository>())
            {
                //var role = roleService.Get(new Guid("E3246743-7F05-43B3-9142-D214B648B830"));
                var user = userService.Get(new Guid("9165331B-191B-4533-A677-E8BB724B9E18"));
                user.Login();
                //user.AttachRole(role);
                user.Roles.Add(role);
                userService.Update(user);
            }
        }
    }
}
