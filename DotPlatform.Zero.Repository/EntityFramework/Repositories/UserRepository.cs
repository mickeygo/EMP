using System.Threading.Tasks;
using DotPlatform.Zero.Domain.Models.Core;
using DotPlatform.Zero.Domain.Repositories;
using DotPlatform.EntityFramework;

namespace DotPlatform.Zero.Repository.EntityFramework.Repositories
{
    internal class UserRepository : ZeroRepository<User>, IUserRepository
    {
        public UserRepository(ISimpleDbContextProvider<ZeroDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public bool Exist(string userName)
        {
            return Count(u => u.UserName == userName) > 0;
        }

        public async Task<bool> ExistAsync(string userName)
        {
            return (await CountAsync(u => u.UserName == userName) > 0);
        }
    }
}
