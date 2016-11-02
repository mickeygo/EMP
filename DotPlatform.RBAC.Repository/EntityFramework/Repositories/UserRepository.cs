using System.Threading.Tasks;
using DotPlatform.EntityFramework;
using DotPlatform.RBAC.Domain.Repositories;
using DotPlatform.RBAC.Domain.Models.Users;

namespace DotPlatform.RBAC.Repository.EntityFramework.Repositories
{
    /// <summary>
    /// User 仓储。可用于 write/read 操作
    /// </summary>
    public class UserRepository : RbacEfRepository<RbacUser>, IUserRepository
    {
        public UserRepository(ISimpleDbContextProvider<RbacEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public RbacUser Find(string userName)
        {
            return FirstOrDefault(u => u.UserName == userName);
        }

        public async Task<RbacUser> FindAsync(string userName)
        {
            return await FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
