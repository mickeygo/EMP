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
            // 1、验证本地数据
            // 1.1、ok，更新本地数据
            // 2、验证远程数据
            // 2.1、ok，新增数据到本地

            var userInfo = new UserInfo(userName);

            var validator = new UserValidator(userName, password);
            if (!(await validator.ValidateInLocal()))
            {
                if (!validator.ValidateInRemote())
                    return false;
            }

            await userInfo.UpdateUser();

            var user = await userInfo.GetLocalUserInfo();
            var tenant = user.Tenant;

            AuthenticationData authenData;
            if (tenant == null)
                authenData = new AuthenticationData(null, null, null, null, user.Id, user.UserName, user.EmailAddress);
            else
                authenData = new AuthenticationData(tenant.Id, tenant.Name, tenant.Language, tenant.TimeDifference, user.Id, user.UserName, user.EmailAddress);

            var authenManager = IocManager.Instance.Resolve<IWebAuthenticationManager>();
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

        #region Private Methods

        #endregion
    }
}
