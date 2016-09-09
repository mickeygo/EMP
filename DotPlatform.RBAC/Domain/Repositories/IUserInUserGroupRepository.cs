using DotPlatform.Domain.Repositories;
using DotPlatform.RBAC.Domain.Models.Users;

namespace DotPlatform.RBAC.Domain.Repositories
{
    /// <summary>
    /// 用户与用户组对应关系
    /// </summary>
    public interface IUserInUserGroupRepository : IRepository<UserInUserGroup>
    {
    }
}
