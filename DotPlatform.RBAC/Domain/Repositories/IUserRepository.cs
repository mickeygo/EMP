using System.Threading.Tasks;
using DotPlatform.RBAC.Domain.Models.Users;
using DotPlatform.Domain.Repositories;

namespace DotPlatform.RBAC.Domain.Repositories
{
    /// <summary>
    /// 用户仓储
    /// </summary>
    public interface IUserRepository : IRepository<RbacUser>
    {
        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        RbacUser Get(string userName);

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        Task<RbacUser> GetAsync(string userName);
    }
}
