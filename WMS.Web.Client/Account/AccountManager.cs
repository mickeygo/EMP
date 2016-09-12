using System.Threading.Tasks;
using DotPlatform.Dependency;
using DotPlatform.Web.Authentication;
using WMS.DataTransferObject.Dtos;
using WMS.Web.Client.Membership;

namespace WMS.Web.Client.Account
{
    /// <summary>
    /// 账户管理
    /// </summary>
    public class AccountManager : IAccount
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="remember"></param>
        /// <returns>True 表示登录成功；否则为 false</returns>
        public async Task<bool> Login(string userName, string password, bool? remember)
        {
            var authenManager = IocManager.Instance.Resolve<IWebAuthenticationManager>();

            var user = await GetUserInfo(userName);
            if (user == null)
                return false;

            var tenant = user.Tenant;

            AuthenticationData authenData;
            if (tenant == null)
                authenData = new AuthenticationData(null, null, null, null, user.Id, user.UserName, user.EmailAddress);
            else
                authenData = new AuthenticationData(tenant.Id, tenant.Name, tenant.Language, tenant.TimeDifference, user.Id, user.UserName, user.EmailAddress);

            authenManager.SignIn(authenData, remember.GetValueOrDefault());

            return true;
        }

        /// <summary>
        /// 用户登出
        /// </summary>
        public void Logout()
        {
            var authenManager = IocManager.Instance.Resolve<IWebAuthenticationManager>();
            authenManager.SignOut();
        }

        private async Task<UserDto> GetUserInfo(string userName)
        {
            var userInfo = new UserInfo(userName);
            return await userInfo.GetLocalUserInfo();
        }
    }
}
