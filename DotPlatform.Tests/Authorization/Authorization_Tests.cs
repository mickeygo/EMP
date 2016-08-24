using DotPlatform.Authorization;
using DotPlatform.Dependency;
using DotPlatform.TestBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.Authorization
{
    [TestClass]
    public class Authorization_Tests : UnitTestBase
    {
        protected override void PostInitialize()
        {
            IocManager.Instance.Register(typeof(MyAuthorizationProvider1));
            IocManager.Instance.Build();
        }

        [TestMethod]
        public void PermissionManager_Test()
        {
            var configurarion = new AuthorizationConfiguration();
            configurarion.Providers.Add<MyAuthorizationProvider1>();

            var permissionManager = new PermissionManager(configurarion);
            permissionManager.Initialize();

            var permission1 = permissionManager.GetPermission("MainMenu1");
            Assert.IsNotNull(permission1);
            Assert.IsTrue(permission1.Children[0].Name == "ChildrenMenu1_1");
        }

        public class MyAuthorizationProvider1 : AuthorizationProvider
        {
            public override void SetPermissions(IPermissionDefinitionContext context)
            {
                context.CreatePermission("MainMenu1", "Main Menu1", false, "Main Menu1 Desc")
                    .CreateChildPermission("ChildrenMenu1_1", "Children Menu1_1", false, "Children Menu1_1 Desc")
                    .CreateChildPermission("ChildrenMenu1_2", "Children Menu1_2", false, "Children Menu1_2 Desc");

                context.CreatePermission("MainMenu2", "Main Menu2", false, "Main Menu2 Desc")
                    .CreateChildPermission("ChildrenMenu2_1", "Children Menu2_1", false, "Children Menu2_1 Desc")
                    .CreateChildPermission("ChildrenMenu2_2", "Children Menu2_2", false, "Children Menu2_2 Desc");
            }
        }
    }
}
