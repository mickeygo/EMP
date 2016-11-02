using DotPlatform.RBAC.Domain.Models.Users;

namespace DotPlatform.RBAC.Domain.QueryRepositories
{
    /// <summary>
    /// 用户存储接口
    /// </summary>
    public interface IUserQueryStorage
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <returns></returns>
        RbacUser GetUser(string userName);
    }
}
