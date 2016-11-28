using DotPlatform.EntityFramework;
using DotPlatform.Zero.Domain.Models.Core;
using DotPlatform.Zero.Domain.Repositories;

namespace DotPlatform.Zero.Repository.EntityFramework.Repositories
{
    internal class UserRoleRepository : ZeroRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ISimpleDbContextProvider<ZeroDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
