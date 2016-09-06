using DotPlatform.Domain.Entities;
using DotPlatform.EntityFramework;
using DotPlatform.EntityFramework.Repositories;

namespace WMS.Domain.Repository
{
    /// <summary>
    /// WMS 系统仓储。基于 Microsoft EntityFramework 框架。
    /// 只用于 ReadOnly.
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合根类型，主键为<see cref="System.Guid"/></typeparam>
    public class WmsReadEfRepository<TAggregateRoot> : EfRepository<WmsReadEfDbContext, TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        public WmsReadEfRepository(ISimpleDbContextProvider<WmsReadEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
