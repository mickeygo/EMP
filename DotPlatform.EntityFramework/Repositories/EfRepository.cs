using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
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
        private readonly IDbContextProvider<TDbContext> _dbContextProvider;

        /// <summary>
        /// 获取上下文对象
        /// </summary>
        public virtual TDbContext Context
        {
            get { return _dbContextProvider.DbContext; }
        }

        /// <summary>
        /// 获取聚合根上下文对象
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
            return AggregateRootContext.Add(aggregateRoot); // 等同于将实体设为 EntityState.Added 状态
        }

        public override TAggregateRoot Update(TAggregateRoot aggregateRoot)
        {
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
                {
                    return;
                }
            }

            Delete(aggregateRoot);
        }

        public override void Delete(TAggregateRoot aggregateRoot)
        {
            this.AttachIfNot(aggregateRoot);
            if (aggregateRoot is ISoftDelete)
            {
                (aggregateRoot as ISoftDelete).IsDeleted = true;
            }
            else
            {
                AggregateRootContext.Remove(aggregateRoot);
            }
        }

        public override async Task<int> CountAsync()
        {
            return await this.AggregateRootContext.CountAsync();
        }

        public override async Task<int> CountAsync(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return await this.AggregateRootContext.CountAsync(predicate);
        }

        public override async Task<int> CountAsync(ISpecification<TAggregateRoot> specification)
        {
            return await this.AggregateRootContext.CountAsync(specification.GetExpression());
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// 检查是否附加了实体，若没有附加实体，则将实体附加
        /// </summary>
        protected virtual void AttachIfNot(TAggregateRoot aggregateRoot)
        {
            if (!AggregateRootContext.Local.Contains(aggregateRoot))
            {
                AggregateRootContext.Attach(aggregateRoot);     // 等同于将实体设为 EntityState.Unchanged 状态
            }
        }

        #endregion
    }

    /// <summary>
    /// 基于 Microsoft EntityFramework 的仓储。主键类型 为 Guid
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
