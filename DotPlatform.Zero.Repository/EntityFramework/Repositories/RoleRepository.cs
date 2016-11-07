using System.Threading.Tasks;
using DotPlatform.Zero.Domain.Models.Core;
using DotPlatform.Zero.Domain.Repositories;
using DotPlatform.EntityFramework;

namespace DotPlatform.Zero.Repository.EntityFramework.Repositories
{
    internal class RoleRepository : ZeroRepository<Role>, IRoleRepository
    {
        public RoleRepository(ISimpleDbContextProvider<ZeroDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public bool Exist(string name)
        {
            return Count(r => r.Name == name) > 0;
        }

        public async Task<bool> ExistAsync(string name)
        {
            return (await CountAsync(r => r.Name == name) > 0);
        }
    }
}
