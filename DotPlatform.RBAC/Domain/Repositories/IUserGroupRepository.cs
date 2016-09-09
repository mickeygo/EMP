using DotPlatform.Domain.Repositories;
using DotPlatform.RBAC.Domain.Models.Users;

namespace DotPlatform.RBAC.Domain.Repositories
{
    /// <summary>
    /// 用户组仓储
    /// </summary>
    public interface IUserGroupRepository : IRepository<RbacUserGroup>
    {
        /// <summary>
        /// 查找用户组
        /// </summary>
        /// <param name="name">用户组名</param>
        /// <returns></returns>
        RbacUser Get(string name);
    }
}
