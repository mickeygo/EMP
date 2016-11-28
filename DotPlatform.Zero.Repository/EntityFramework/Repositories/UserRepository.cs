using System.Threading.Tasks;
using DotPlatform.Zero.Domain.Models.Core;
using DotPlatform.Zero.Domain.Repositories;
using DotPlatform.EntityFramework;

namespace DotPlatform.Zero.Repository.EntityFramework.Repositories
{
    /// <summary>
    /// 用户仓储
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    internal class UserRepository : ZeroRepository<User>, IUserRepository
    {
        public UserRepository(ISimpleDbContextProvider<ZeroDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public bool Exist(string name)
        {
            return Count(u => u.UserName == name) > 0;
        }

        public async Task<bool> ExistAsync(string name)
        {
            return (await CountAsync(u => u.UserName == name) > 0);
        }
    }
}
