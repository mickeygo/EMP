using DotPlatform.Domain.Entities;
using DotPlatform.EntityFramework;
using DotPlatform.EntityFramework.Repositories;

namespace DotPlatform.RBAC.Repository
{
    /// <summary>
    /// RBAC 系统仓储。基于 Microsoft EntityFramework 框架。
    /// 这里使用 <see cref="ISimpleDbContextProvider{}"/> 做简单的仓储处理。
    /// 当调用 Dispose() 方法时会执行 SaveChanges() 方法并调用 Dispose 方法来释放资源。
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合根类型，主键为<see cref="System.Guid"/></typeparam>
    public abstract class RbacEfRepository<TAggregateRoot> : EfRepository<RbacEfDbContext, TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        protected RbacEfRepository(ISimpleDbContextProvider<RbacEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
            
        }

        /// <summary>
        /// 重写 Dispose 方法。调用此方法会执行 SaveChanges 动作, 并释放对象所占用的资源
        /// </summary>
        public override void Dispose()
        {
            // Todo: 如何在没有 CUD 时不执行 SaveChanges 方法, 或是如何让手动执行 SaveChanges 方法
            Context.SaveChanges();
            base.Dispose();
        }
    }
}
