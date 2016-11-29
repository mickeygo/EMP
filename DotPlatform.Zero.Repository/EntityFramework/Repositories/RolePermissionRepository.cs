using DotPlatform.Zero.Domain.Models.Core;
using DotPlatform.Zero.Domain.Repositories;
using DotPlatform.EntityFramework;

namespace DotPlatform.Zero.Repository.EntityFramework.Repositories
{
    internal class RolePermissionRepository : ZeroRepository<RolePermission>, IRolePermissionRepository
    {
        public RolePermissionRepository(ISimpleDbContextProvider<ZeroDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
