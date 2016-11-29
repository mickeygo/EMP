using System.Threading.Tasks;
using DotPlatform.Zero.Domain.Repositories;
using DotPlatform.Zero.Domain.Models.Core;
using DotPlatform.EntityFramework;

namespace DotPlatform.Zero.Repository.EntityFramework.Repositories
{
    internal class PermissionRepository : ZeroRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(ISimpleDbContextProvider<ZeroDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public bool Exist(string name)
        {
            return Count(p => p.Name == name) > 0;
        }

        public async Task<bool> ExistAsync(string name)
        {
            return (await CountAsync(p => p.Name == name) > 0);
        }
    }
}
