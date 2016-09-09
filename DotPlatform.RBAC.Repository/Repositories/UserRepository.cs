using System.Threading.Tasks;
using DotPlatform.EntityFramework;
using DotPlatform.RBAC.Domain.Repositories;
using DotPlatform.RBAC.Domain.Models.Users;

namespace DotPlatform.RBAC.Repository.Repositories
{
    /// <summary>
    /// User 仓储
    /// </summary>
    public class UserRepository : RbacEfRepository<RbacUser>, IUserRepository
    {
        public UserRepository(IDbContextProvider<RbacEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public RbacUser Get(string userNamename)
        {
            return FirstOrDefault(u => u.UserName == userNamename);
        }

        public async Task<RbacUser> GetAsync(string userNamename)
        {
            return await FirstOrDefaultAsync(u => u.UserName == userNamename);
        }
    }
}
