using System;
using DotPlatform.Domain.Entities;

namespace DotPlatform.Domain.Repositories
{
    /// <summary>
    /// 表示实现此接口类为仓储对象
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合根类型，<see cref="IAggregateRoot"/></typeparam>
    /// <typeparam name="TKey">聚合根主键</typeparam>
    public interface IRepository<TAggregateRoot, TKey> : IRepositoryQuery<TAggregateRoot, TKey>,
                                                         IRepositoryCommand<TAggregateRoot, TKey>
        where TAggregateRoot : IAggregateRoot<TKey>
    {
        
    }

    /// <summary>
    /// 表示实现此接口类为仓储对象
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合根类型，<see cref="IAggregateRoot"/></typeparam>
    public interface IRepository<TAggregateRoot> : IRepository<TAggregateRoot, Guid>
        where TAggregateRoot : IAggregateRoot<Guid>
    {
        
    }
}
