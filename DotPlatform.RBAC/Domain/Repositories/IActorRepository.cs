using DotPlatform.Domain.Repositories;
using DotPlatform.RBAC.Domain.Models.Actors;

namespace DotPlatform.RBAC.Domain.Repositories
{
    /// <summary>
    /// Actor 仓储
    /// </summary>
    public interface IActorRepository : IRepository<RbacActor>
    {
        /// <summary>
        /// 是否存在此行为
        /// </summary>
        /// <param name="name">Actor 名称</param>
        /// <returns>True 表示存在；否则为 False</returns>
        bool Exist(string name);
    }
}
