using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DotPlatform.Domain.Entities;
using DotPlatform.Specifications;

namespace DotPlatform.Domain.Repositories
{
    /// <summary>
    /// 仓储基类
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合根类型，参见<see cref="IAggregateRoot"/></typeparam>
    /// <typeparam name="TKey">主键类型</typeparam>
    public abstract class RepositoryBase<TAggregateRoot, TKey> : IRepository<TAggregateRoot, TKey>
        where TAggregateRoot : IAggregateRoot<TKey>
    {
        #region IRepository<TAggregateRoot,TKey> Members

        public abstract IQueryable<TAggregateRoot> GetAll();

        public virtual List<TAggregateRoot> GetAllList()
        {
            return this.GetAll().ToList();
        }
        
        public virtual async Task<List<TAggregateRoot>> GetAllListAsync()
        {
            return await Task.FromResult(this.GetAllList());
        }

        public virtual List<TAggregateRoot> GetAllList(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return this.GetAll().Where(predicate).ToList();
        }

        public virtual async Task<List<TAggregateRoot>> GetAllListAsync(
            Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return await Task.FromResult(this.GetAllList());
        }

        public virtual List<TAggregateRoot> GetAllList(ISpecification<TAggregateRoot> specification)
        {
            return this.GetAll().Where(specification.GetExpression()).ToList();
        }

        public virtual async Task<List<TAggregateRoot>> GetAllListAsync(ISpecification<TAggregateRoot> specification)
        {
            return await Task.FromResult(this.GetAllList(specification.GetExpression()));
        }

        public virtual TAggregateRoot Get(TKey id)
        {
            var aggregate = this.GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
            if (aggregate == null)
            {
                throw new InvalidOperationException("There is no such an entity with given primary key. Entity type: " +
                                                    typeof (TAggregateRoot).FullName + ", primary key: " + id);
            }

            return aggregate;
        }

        public virtual async Task<TAggregateRoot> GetAsync(TKey id)
        {
            var aggregate = this.GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
            if (aggregate == null)
            {
                throw new InvalidOperationException("There is no such an entity with given primary key. Entity type: " +
                                                    typeof (TAggregateRoot).FullName + ", primary key: " + id);
            }

            return await Task.FromResult(aggregate);
        }

        public virtual TAggregateRoot Single(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return this.GetAll().Single(predicate);
        }

        public virtual async Task<TAggregateRoot> SingleAsync(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return await Task.FromResult(this.Single(predicate));
        }

        public virtual TAggregateRoot Single(ISpecification<TAggregateRoot> specification)
        {
            return this.GetAll().Single(specification.GetExpression());
        }

        public virtual async Task<TAggregateRoot> SingleAsync(ISpecification<TAggregateRoot> specification)
        {
            return await Task.FromResult(this.Single(specification.GetExpression()));
        }

        public virtual TAggregateRoot FirstOrDefault(TKey id)
        {
            return this.GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        public virtual async Task<TAggregateRoot> FirstOrDefaultAsync(TKey id)
        {
            return await Task.FromResult(this.FirstOrDefault(id));
        }

        public virtual TAggregateRoot FirstOrDefault(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return this.GetAll().FirstOrDefault(predicate);
        }

        public virtual async Task<TAggregateRoot> FirstOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return await Task.FromResult(this.FirstOrDefault(predicate));
        }

        public virtual TAggregateRoot FirstOrDefault(ISpecification<TAggregateRoot> specification)
        {
            return this.GetAll().FirstOrDefault(specification.GetExpression());
        }

        public virtual async Task<TAggregateRoot> FirstOrDefaultAsync(ISpecification<TAggregateRoot> specification)
        {
            return await Task.FromResult(this.FirstOrDefault(specification.GetExpression()));
        }

        public abstract TAggregateRoot Add(TAggregateRoot aggregate);

        public virtual async Task<TAggregateRoot> AddAsync(TAggregateRoot aggregate)
        {
            return await Task.FromResult(this.Add(aggregate));
        }

        public abstract TAggregateRoot Update(TAggregateRoot aggregate);

        public virtual async Task<TAggregateRoot> UpdateAsync(TAggregateRoot aggregate)
        {
            return await Task.FromResult(this.Update(aggregate));
        }

        public abstract void Delete(TAggregateRoot aggregate);

        public virtual Task DeleteAsync(TAggregateRoot aggregate)
        {
            this.Delete(aggregate);
            return Task.FromResult(0);
        }

        public abstract void Delete(TKey id);

        public virtual Task DeleteAsync(TKey id)
        {
            this.Delete(id);
            return Task.FromResult(0);
        }

        public virtual int Count()
        {
            return this.GetAll().Count();
        }

        public virtual async Task<int> CountAsync()
        {
            return await Task.FromResult(this.Count());
        }

        public virtual int Count(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return this.GetAll().Count(predicate);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return await Task.FromResult(this.Count(predicate));
        }

        public virtual int Count(ISpecification<TAggregateRoot> specification)
        {
            return this.GetAll().Count(specification.GetExpression());
        }

        public virtual async Task<int> CountAsync(ISpecification<TAggregateRoot> specification)
        {
            return await Task.FromResult(this.Count(specification.GetExpression()));
        }

        public virtual void Dispose()
        {
        }

        #endregion

        protected static Expression<Func<TAggregateRoot, bool>> CreateEqualityExpressionForId(TKey id)
        {
            var lambdaParam = Expression.Parameter(typeof (TAggregateRoot));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof (TKey))
                );

            return Expression.Lambda<Func<TAggregateRoot, bool>>(lambdaBody, lambdaParam);
        }
    }

    /// <summary>
    /// 仓储基类
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合根类型，参见<see cref="IAggregateRoot"/></typeparam>
    public abstract class RepositoryBase<TAggregateRoot> : RepositoryBase<TAggregateRoot, Guid>,
                                                           IRepository<TAggregateRoot>
        where TAggregateRoot : IAggregateRoot<Guid>
    {

    }
}
