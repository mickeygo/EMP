using System.Threading.Tasks;
using DotPlatform.Domain.Repositories;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Domain.Repositories
{
    /// <summary>
    /// 基于 Zero 模块的角色仓储
    /// </summary>
    public interface IRoleRepository : IRepository<Role>
    {
        /// <summary>
        /// 是否已存在此角色
        /// </summary>
        /// <param name="name">角色名</param>
        /// <returns></returns>
        bool Exist(string name);

        /// <summary>
        /// 是否已存在此角色
        /// </summary>
        /// <param name="name">角色名</param>
        /// <returns></returns>
        Task<bool> ExistAsync(string name);
    }
}
