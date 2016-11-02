using DotPlatform.Configuration;
using DotPlatform.Dependency;
using DotPlatform.RBAC.Authorization;

namespace DotPlatform.RBAC
{
    internal class RbacBootStrapper : IApplicationInitializer
    {
        public void Initialize()
        {
            IocManager.Instance.Register<RbacUserManager>();

            //
            IocManager.Instance.Register<IUserStore, UserStore>();


            IocManager.Instance.Build();
        }
    }
}
