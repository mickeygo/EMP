﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Repositories;
using DotPlatform.Specifications;

namespace DotPlatform.EntityFramework.Repositories
{
    /// <summary>
    /// 基于 Microsoft EntityFramework 的仓储。
    /// 用于对聚合根对象进行增删改查。
    /// </summary>
    /// <typeparam name="TDbContext">基于<see cref="DbContext"/>的数据上下文</typeparam>
    /// <typeparam name="TAggregateRoot">聚合根类型，参见<see cref="IAggregateRoot"/></typeparam>
    /// <typeparam name="TKey">主键类型</typeparam>
    public class EfRepository<TDbContext, TAggregateRoot, TKey> : RepositoryBase<TAggregateRoot, TKey>
         where TAggregateRoot : class, IAggregateRoot<TKey>
         where TDbContext : DbContext
    {
        private readonly DbCommandCounter _counter = new DbCommandCounter();
        private readonly IDbContextProvider<TDbContext> _dbContextProvider;
        private bool isDisposed;

        /// <summary>
        /// 是否追踪对象, 默认为 true.
        /// </summary>
        public bool Tracking { get; protected set; } = true;
        
        /// <summary>
        /// Command 命令计数器
        /// </summary>
        public DbCommandCounter CommandCounter
        {
            get { return _counter; }
        }

        /// <summary>
        /// 获取Db上下文对象
        /// </summary>
        public virtual TDbContext Context
        {
            get { return _dbContextProvider.DbContext; }
        }

        /// <summary>
        /// 获取聚合根对象的数据集合
        /// </summary>
        public virtual DbSet<TAggregateRoot> AggregateRootContext
        {
            get { return Context.Set<TAggregateRoot>(); }
        }

        /// <summary>
        /// 初始化一个新的<c>EfRepository</c>实例
        /// </summary>
        /// <param name="dbContextProvider"></param>
        public EfRepository(IDbContextProvider<TDbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        #region Public Methods

        public override IQueryable<TAggregateRoot> GetAll()
        {
            if (!Tracking)
                return AggregateRootContext.AsNoTracking();

            return AggregateRootContext;
        }

        public override async Task<List<TAggregateRoot>> GetAllListAsync()
        {
            return await AggregateRootContext.ToListAsync();
        }

        public override async Task<TAggregateRoot> SingleAsync(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return await AggregateRootContext.SingleAsync(predicate);
        }

        public override async Task<TAggregateRoot> SingleAsync(ISpecification<TAggregateRoot> specification)
        {
            return await AggregateRootContext.SingleAsync(specification.GetExpression());
        }

        public override async Task<TAggregateRoot> FirstOrDefaultAsync(TKey id)
        {
            return await AggregateRootContext.FirstOrDefaultAsync(CreateEqualityExpressionForId(id));
        }

        public override async Task<TAggregateRoot> FirstOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return await AggregateRootContext.FirstOrDefaultAsync(predicate);
        }

        public override async Task<TAggregateRoot> FirstOrDefaultAsync(ISpecification<TAggregateRoot> specification)
        {
            return await AggregateRootContext.FirstOrDefaultAsync(specification.GetExpression());
        }

        public override TAggregateRoot Add(TAggregateRoot aggregateRoot)
        {
            _counter.AddIncrease();

            return AggregateRootContext.Add(aggregateRoot); // 等同于将实体设为 EntityState.Added 状态
        }

        public override TAggregateRoot Update(TAggregateRoot aggregateRoot)
        {
            _counter.UpdateIncrease();

            this.AttachIfNot(aggregateRoot);
            Context.Entry(aggregateRoot).State = EntityState.Modified;
            return aggregateRoot;
        }

        public override void Delete(TKey id)
        {
            var aggregateRoot = AggregateRootContext.Local.FirstOrDefault(agg => EqualityComparer<TKey>.Default.Equals(agg.Id, id));
            if (aggregateRoot == null)
            {
                aggregateRoot = this.FirstOrDefault(id);
                if (aggregateRoot == null)
                    return;
            }

            Delete(aggregateRoot);
        }

        public override void Delete(TAggregateRoot aggregateRoot)
        {
            this.AttachIfNot(aggregateRoot);
            if (aggregateRoot is ISoftDelete)
            {
                (aggregateRoot as ISoftDelete).IsDeleted = true;
                _counter.UpdateIncrease();
            }
            else
            {
                AggregateRootContext.Remove(aggregateRoot);
                _counter.DeleteIncrease();
            }
        }

        public override async Task<int> CountAsync()
        {
            return await AggregateRootContext.CountAsync();
        }

        public override async Task<int> CountAsync(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return await AggregateRootContext.CountAsync(predicate);
        }

        public override async Task<int> CountAsync(ISpecification<TAggregateRoot> specification)
        {
            return await AggregateRootContext.CountAsync(specification.GetExpression());
        }

        public override void Dispose()
        {
            if (!isDisposed)
            {
                Context.Dispose();
                isDisposed = true;
                _counter.Reset();
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// 检查当前聚合上下文是否附加了实体，若没有附加实体，则将实体附加到当前上下文
        /// </summary>
        protected virtual void AttachIfNot(TAggregateRoot aggregateRoot)
        {
            if (!AggregateRootContext.Local.Contains(aggregateRoot))
            {
                AggregateRootContext.Attach(aggregateRoot);     // equal to 'EntityState.Unchanged' state
            }
        }

        #endregion
    }

    /// <summary>
    /// 基于 Microsoft EntityFramework 的仓储。主键类型 为 <see cref="Guid"/>
    /// 用于对聚合根对象进行增删改查。
    /// </summary>
    /// <typeparam name="TDbContext">基于<see cref="DbContext"/>的数据上下文</typeparam>
    /// <typeparam name="TAggregateRoot">聚合根类型，参见<see cref="IAggregateRoot"/></typeparam>
    public class EfRepository<TDbContext, TAggregateRoot> : EfRepository<TDbContext, TAggregateRoot, Guid>
        where TAggregateRoot : class, IAggregateRoot
        where TDbContext : DbContext
    {
        public EfRepository(IDbContextProvider<TDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
