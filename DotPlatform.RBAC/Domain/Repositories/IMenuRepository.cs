using DotPlatform.Domain.Repositories;
using DotPlatform.RBAC.Domain.Models.Menus;

namespace DotPlatform.RBAC.Domain.Repositories
{
    /// <summary>
    /// 菜单仓储
    /// </summary>
    public interface IMenuRepository : IRepository<RbacMenu>
    {
        /// <summary>
        /// 是否存在此菜单
        /// </summary>
        /// <param name="name">菜单名称</param>
        /// <returns>True 表示存在；否则为 False</returns>
        bool Exist(string name);
    }
}
