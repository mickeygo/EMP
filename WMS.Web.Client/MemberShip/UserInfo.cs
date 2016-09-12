using System.Threading.Tasks;
using DotPlatform.Dependency;
using DotPlatform.RBAC.Authorization;
using WMS.DataTransferObject.Dtos;
using DotPlatform.AutoMapper;

namespace WMS.Web.Client.Membership
{
    /// <summary>
    /// 用于查询用户相关信息
    /// </summary>
    public class UserInfo
    {
        private readonly string _usernName;

        /// <summary>
        /// 初始化一个新的<see cref="UserInfo"/>实例
        /// </summary>
        /// <param name="usernName">用户名</param>
        public UserInfo(string usernName)
        {
            _usernName = usernName;
        }

        /// <summary>
        /// 获取本地用户信息
        /// </summary>
        /// <returns></returns>
        public async Task<UserDto> GetLocalUserInfo()
        {
            using (var service = IocManager.Instance.Resolve<RbacUserManager>())
            {
                var user = await service.FindByNameAsync(_usernName);
                return user.MapTo<UserDto>();
            }
        }

        /// <summary>
        /// 获取远端用户信息
        /// </summary>
        /// <returns></returns>
        public UserDto GetRemoteUserInfo()
        {
            return null;
        }
    }
}
