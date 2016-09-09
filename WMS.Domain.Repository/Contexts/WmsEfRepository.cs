using DotPlatform.Domain.Entities;
using DotPlatform.EntityFramework.Repositories;
using DotPlatform.EntityFramework;

namespace WMS.Domain.Repository
{
    /// <summary>
    /// WMS 系统仓储。基于 Microsoft EntityFramework 框架
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合根类型，主键为<see cref="System.Guid"/></typeparam>
    public class WmsEfRepository<TAggregateRoot> : EfRepository<WmsEfDbContext, TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        public WmsEfRepository(IDbContextProvider<WmsEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
