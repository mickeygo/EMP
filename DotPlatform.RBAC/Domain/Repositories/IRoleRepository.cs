using DotPlatform.Domain.Repositories;
using DotPlatform.RBAC.Domain.Models.Roles;

namespace DotPlatform.RBAC.Domain.Repositories
{
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : IRepository<RbacRole>
    {
        /// <summary>
        /// 是否存在此角色
        /// </summary>
        /// <param name="name">角色名称</param>
        /// <returns>True 表示存在；否则为 False</returns>
        bool Exist(string name);
    }
}
