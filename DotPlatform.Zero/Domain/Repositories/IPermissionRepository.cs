using System.Threading.Tasks;
using DotPlatform.Domain.Repositories;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Domain.Repositories
{
    /// <summary>
    /// 基于 Zero 模块的权限仓储
    /// </summary>
    public interface IPermissionRepository : IRepository<Permission>
    {
        /// <summary>
        /// 是否已存在此权限
        /// </summary>
        /// <param name="name">权限名</param>
        /// <returns></returns>
        bool Exist(string name);

        /// <summary>
        /// 是否已存在此权限
        /// </summary>
        /// <param name="name">权限名</param>
        /// <returns></returns>
        Task<bool> ExistAsync(string name);
    }
}
