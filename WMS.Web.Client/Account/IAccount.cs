using System.Threading.Tasks;

namespace WMS.Web.Client.Account
{
    public interface IAccount
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="remember"></param>
        /// <returns></returns>
        Task<bool> Login(string userName, string password, bool? remember);

        /// <summary>
        /// 当前用户登出
        /// </summary>
        void Logout();
    }
}
