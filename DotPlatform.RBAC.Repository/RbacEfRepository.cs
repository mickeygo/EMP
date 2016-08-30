using DotPlatform.Domain.Entities;
using DotPlatform.EntityFramework;
using DotPlatform.EntityFramework.Repositories;

namespace DotPlatform.RBAC.Repository
{
    /// <summary>
    /// RBAC 系统仓储。基于 Microsoft EntityFramework 框架
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合根类型，主键为<see cref="System.Guid"/></typeparam>
    public abstract class RbacEfRepository<TAggregateRoot> : EfRepository<RbacEfDbContext, TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        protected RbacEfRepository(IDbContextProvider<RbacEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
