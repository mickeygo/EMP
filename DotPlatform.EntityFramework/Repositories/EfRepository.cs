using System.Data.Entity;
using System.Linq;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotPlatform.Specifications;
using System;
using System.Linq.Expressions;

namespace DotPlatform.EntityFramework.Repositories
{
    /// <summary>
    /// 基于 Microsoft EntityFramework 的仓储
    /// </summary>
    /// <typeparam name="TDbContext">数据上下文</typeparam>
    /// <typeparam name="TAggregateRoot">聚合根类型，参见<see cref="IAggregateRoot"/></typeparam>
    /// <typeparam name="TKey">主键类型</typeparam>
    public class EfRepository<TDbContext, TAggregateRoot, TKey> : RepositoryBase<TAggregateRoot, TKey>
         where TAggregateRoot : class, IAggregateRoot<TKey>
         where TDbContext : DbContext
    {
        private readonly IDbContextProvider<TDbContext> _dbContextProvider;

        public virtual TDbContext Context
        {
            get { return _dbContextProvider.DbContext; }
        }

        public virtual DbSet<TAggregateRoot> AggregateRootSet
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
            return AggregateRootSet;
        }

        public override async Task<List<TAggregateRoot>> GetAllListAsync()
        {
            return await AggregateRootSet.ToListAsync();
        }

        public override async Task<TAggregateRoot> SingleAsync(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return await AggregateRootSet.SingleAsync(predicate);
        }

        public override async Task<TAggregateRoot> SingleAsync(ISpecification<TAggregateRoot> specification)
        {
            return await AggregateRootSet.SingleAsync(specification.GetExpression());
        }

        public override async Task<TAggregateRoot> FirstOrDefaultAsync(TKey id)
        {
            return await AggregateRootSet.FirstOrDefaultAsync(CreateEqualityExpressionForId(id));
        }

        public override async Task<TAggregateRoot> FirstOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return await AggregateRootSet.FirstOrDefaultAsync(predicate);
        }

        public override async Task<TAggregateRoot> FirstOrDefaultAsync(ISpecification<TAggregateRoot> specification)
        {
            return await AggregateRootSet.FirstOrDefaultAsync(specification.GetExpression());
        }

        public override TAggregateRoot Add(TAggregateRoot aggregateRoot)
        {
            return AggregateRootSet.Add(aggregateRoot);
        }

        public override TAggregateRoot Update(TAggregateRoot aggregateRoot)
        {
            this.AttachIfNot(aggregateRoot);
            Context.Entry(aggregateRoot).State = EntityState.Modified;
            return aggregateRoot;
        }

        public override void Delete(TKey id)
        {
            var aggregateRoot = AggregateRootSet.Local.FirstOrDefault(agg => EqualityComparer<TKey>.Default.Equals(agg.Id, id));
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
                AggregateRootSet.Remove(aggregateRoot);
            }
        }

        public override async Task<int> CountAsync()
        {
            return await this.AggregateRootSet.CountAsync();
        }

        public override async Task<int> CountAsync(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return await this.AggregateRootSet.CountAsync(predicate);
        }

        public override async Task<int> CountAsync(ISpecification<TAggregateRoot> specification)
        {
            return await this.AggregateRootSet.CountAsync(specification.GetExpression());
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// 检查是否附加了实体，若没有附加实体，则将实体附加
        /// </summary>
        protected virtual void AttachIfNot(TAggregateRoot aggregateRoot)
        {
            if (!AggregateRootSet.Local.Contains(aggregateRoot))
            {
                AggregateRootSet.Attach(aggregateRoot);
            }
        }

        #endregion
    }

    /// <summary>
    /// 基于 Microsoft EntityFramework 的仓储
    /// </summary>
    /// <typeparam name="TDbContext">数据上下文</typeparam>
    /// <typeparam name="TAggregateRoot">聚合根类型，参见<see cref="IAggregateRoot"/></typeparam>
    public class EfRepository<TDbContext, TAggregateRoot> : EfRepository<TDbContext, TAggregateRoot, Guid>
        where TAggregateRoot : class, IAggregateRoot<Guid>
        where TDbContext : DbContext
    {
        public EfRepository(IDbContextProvider<TDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {

        }
    }
}
