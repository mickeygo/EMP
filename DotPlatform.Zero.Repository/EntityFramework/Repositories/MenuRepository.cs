using DotPlatform.Zero.Domain.Models.Core;
using DotPlatform.Zero.Domain.Repositories;
using DotPlatform.EntityFramework;

namespace DotPlatform.Zero.Repository.EntityFramework.Repositories
{
    internal class MenuRepository : ZeroRepository<Menu>, IMenuRepository
    {
        public MenuRepository(ISimpleDbContextProvider<ZeroDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
