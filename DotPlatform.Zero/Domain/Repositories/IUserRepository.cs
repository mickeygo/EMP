using System.Threading.Tasks;
using DotPlatform.Domain.Repositories;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Domain.Repositories
{
    /// <summary>
    /// 基于 Zero 模块的用户仓储
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// 是否已存在此用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        bool Exist(string userName);

        /// <summary>
        /// 是否已存在此用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        Task<bool> ExistAsync(string userName);
    }
}
