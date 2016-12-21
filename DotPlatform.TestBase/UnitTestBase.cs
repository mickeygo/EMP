using DotPlatform.Reflection;
using DotPlatform.Runtime.Security;
using System.Security.Claims;
using System.Threading;

namespace DotPlatform.TestBase
{
    /// <summary>
    /// 单元测试基类
    /// </summary>
    public abstract class UnitTestBase
    {
        protected UnitTestBase()
        {
            PreInitialize();
            InitIocContainer();
            PostInitialize();
        }

        protected virtual void PreInitialize()
        {
            AssemblyLoadHelper.LoadAssembly("WMS");
        }

        protected virtual void PostInitialize()
        {
            SetSession();
        }

        protected virtual void MakeSession(TestIdentity identity)
        {
            
        }

        private void InitIocContainer()
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.PreInitializeEvent += (o, s) => PreInitialize();
            bootstrapper.PostInitializeEvent += (o, s) => PostInitialize();

            bootstrapper.Start();
        }

        private void SetSession()
        {
            var tIdentity = new TestIdentity();
            MakeSession(tIdentity);

            var identity = new ClaimsIdentity(tIdentity.AuthenticationType ?? "ApplicationCookie");
            identity.AddClaim(new Claim(OwnerClaimTypes.TenantId, tIdentity.TenantId ?? ""));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, tIdentity.UserId ?? ""));
            identity.AddClaim(new Claim(OwnerClaimTypes.TimeDifference, tIdentity.TimeDiff.ToString()));

            //var identity = new ClaimsIdentity("ApplicationCookie");
            //identity.AddClaim(new Claim(OwnerClaimTypes.TenantId, "B57F407F-53CB-4D8F-A7D8-EFBE0A213F68"));
            //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "7BF86867-0C79-46AA-8BF9-6EEE6A98360A"));
            //identity.AddClaim(new Claim(OwnerClaimTypes.TimeDifference, "0"));

            var principal = new ClaimsPrincipal(identity);

            Thread.CurrentPrincipal = principal;
        }
    }
}
