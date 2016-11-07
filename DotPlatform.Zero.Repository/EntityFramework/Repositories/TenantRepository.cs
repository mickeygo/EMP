using System.Threading.Tasks;
using DotPlatform.EntityFramework;
using DotPlatform.Zero.Domain.Models.Core;
using DotPlatform.Zero.Domain.Repositories;

namespace DotPlatform.Zero.Repository.EntityFramework.Repositories
{
    internal class TenantRepository : ZeroRepository<Tenant>, ITenantRepository
    {
        public TenantRepository(ISimpleDbContextProvider<ZeroDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public bool Exist(string tenantName)
        {
            return Count(t => t.Name == tenantName) > 0;
        }

        public async Task<bool> ExistAsync(string tenantName)
        {
            return (await CountAsync(t => t.Name == tenantName) > 0);
        }
    }
}
