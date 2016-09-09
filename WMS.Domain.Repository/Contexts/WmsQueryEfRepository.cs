using DotPlatform.Domain.Entities;
using DotPlatform.EntityFramework;
using DotPlatform.EntityFramework.Repositories;

namespace WMS.Domain.Repository
{
    /// <summary>
    /// WMS 系统仓储。基于 Microsoft EntityFramework 框架。
    /// 只用于 查询.
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合根类型，主键为<see cref="System.Guid"/></typeparam>
    public class WmsQueryEfRepository<TAggregateRoot> : EfRepository<WmsQueryEfDbContext, TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        public WmsQueryEfRepository(ISimpleDbContextProvider<WmsQueryEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
