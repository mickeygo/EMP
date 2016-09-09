using DotPlatform.Dependency;
using DotPlatform.Web.Authentication;

namespace WMS.Web.Client.Account
{
    /// <summary>
    /// 账户管理
    /// </summary>
    public class AccountManager : IAccount
    {
        public bool Login(string userName, string password, bool? remember)
        {
            var authorManager = IocManager.Instance.Resolve<IWebAuthenticationManager>();
            

            return true;
        }

        public void Logout()
        {
            var authorManager = IocManager.Instance.Resolve<IWebAuthenticationManager>();
            authorManager.SignOut();
        }
    }
}
