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
    /// 表示实现此接口类为仓储对象,用于聚合查询<see cref="IRepository{TAggregateRoot,TKey}"/>
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合根类型，<see cref="IAggregateRoot"/></typeparam>
    /// <typeparam name="TKey">聚合根主键</typeparam>
    public interface IRepositoryQuery<TAggregateRoot, TKey>
        where TAggregateRoot : IAggregateRoot<TKey>
    {
        #region Select

        /// <summary>
        /// <see cref="IQueryable{TAggregateRoot}"/>类型，用于在数据库中检索所有的聚合实体
        /// </summary>
        /// <returns>IQueryable<see cref="IQueryable"/></returns>
        IQueryable<TAggregateRoot> GetAll();

        /// <summary>
        /// 获取满所有的聚合根
        /// </summary>
        /// <returns>TAggregateRoot 集合</returns>
        List<TAggregateRoot> GetAllList();

        /// <summary>
        /// 获取满所有的聚合根
        /// </summary>
        /// <returns>TAggregateRoot 集合</returns>
        Task<List<TAggregateRoot>> GetAllListAsync();

        /// <summary>
        /// 获取满足条件的所有的聚合根
        /// </summary>
        /// <param name="predicate">用于筛选实体的条件</param>
        /// <returns>TAggregateRoot 集合</returns>
        List<TAggregateRoot> GetAllList(Expression<Func<TAggregateRoot, bool>> predicate);

        /// <summary>
        /// 获取满足条件的所有的聚合根
        /// </summary>
        /// <param name="predicate">用于筛选实体的条件</param>
        /// <returns>TAggregateRoot 集合</returns>
        Task<List<TAggregateRoot>> GetAllListAsync(Expression<Func<TAggregateRoot, bool>> predicate);

        /// <summary>
        /// 获取满足条件的所有的聚合根
        /// </summary>
        /// <param name="specification">用于筛选实体的规约</param>
        /// <returns>TAggregateRoot 集合</returns>
        List<TAggregateRoot> GetAllList(ISpecification<TAggregateRoot> specification);

        /// <summary>
        /// 获取满足条件的所有的聚合根
        /// </summary>
        /// <param name="specification">用于筛选实体的规约</param>
        /// <returns>TAggregateRoot 集合</returns>
        Task<List<TAggregateRoot>> GetAllListAsync(ISpecification<TAggregateRoot> specification);

        /// <summary>
        /// 获取指定 Id 的聚合根。
        /// 若找不到指定的聚合根，则引发异常
        /// </summary>
        /// <param name="id">聚合根 Id</param>
        /// <returns>TAggregateRoot</returns>
        TAggregateRoot Get(TKey id);

        /// <summary>
        /// 获取指定 Id 的聚合根。
        /// 若找不到指定的聚合根，则引发异常
        /// </summary>
        /// <param name="id">聚合根 Id</param>
        /// <returns>TAggregateRoot</returns>
        Task<TAggregateRoot> GetAsync(TKey id);

        /// <summary>
        /// 获取唯一一个满足筛选条件的聚合根。
        /// 若没有找到或找到多个聚合根，则引发异常
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns>TAggregateRoot</returns>
        TAggregateRoot Single(Expression<Func<TAggregateRoot, bool>> predicate);

        /// <summary>
        /// 获取唯一一个满足筛选条件的聚合根。
        /// 若没有找到或找到多个聚合根，则引发异常
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns>TAggregateRoot</returns>
        Task<TAggregateRoot> SingleAsync(Expression<Func<TAggregateRoot, bool>> predicate);

        /// <summary>
        /// 获取唯一一个满足筛选条件的聚合根。
        /// 若没有找到或找到多个聚合根，则引发异常
        /// </summary>
        /// <param name="specification">查询规约</param>
        /// <returns>TAggregateRoot</returns>
        TAggregateRoot Single(ISpecification<TAggregateRoot> specification);

        /// <summary>
        /// 获取唯一一个满足筛选条件的聚合根。
        /// 若没有找到或找到多个聚合根，则引发异常
        /// </summary>
        /// <param name="specification">查询规约</param>
        /// <returns>TAggregateRoot</returns>
        Task<TAggregateRoot> SingleAsync(ISpecification<TAggregateRoot> specification);

        /// <summary>
        /// 获取满足筛选条件的第一个聚合根，若没找到，则返回聚合根的默认值
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns>TAggregateRoot</returns>
        TAggregateRoot FirstOrDefault(Expression<Func<TAggregateRoot, bool>> predicate);

        /// <summary>
        /// 获取满足筛选条件的第一个聚合根，若没找到，则返回聚合根的默认值
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns>TAggregateRoot</returns>
        Task<TAggregateRoot> FirstOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> predicate);

        /// <summary>
        /// 获取满足筛选条件的第一个聚合根，若没找到，则返回聚合根的默认值
        /// </summary>
        /// <param name="specification">规约</param>
        /// <returns>TAggregateRoot</returns>
        TAggregateRoot FirstOrDefault(ISpecification<TAggregateRoot> specification);

        /// <summary>
        /// 获取满足筛选条件的第一个聚合根，若没找到，则返回聚合根的默认值
        /// </summary>
        /// <param name="specification">规约</param>
        /// <returns>TAggregateRoot</returns>
        Task<TAggregateRoot> FirstOrDefaultAsync(ISpecification<TAggregateRoot> specification);

        /// <summary>
        /// 获取所有的聚合实体数量
        /// </summary>
        /// <returns>聚合实体数量</returns>
        int Count();

        /// <summary>
        /// 获取所有的聚合实体数量
        /// </summary>
        /// <returns>聚合实体数量</returns>
        Task<int> CountAsync();

        /// <summary>
        /// 获取满足筛选条件的聚合实体数量
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns>聚合实体数量</returns>
        int Count(Expression<Func<TAggregateRoot, bool>> predicate);

        /// <summary>
        /// 获取满足筛选条件的聚合实体数量
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns>聚合实体数量</returns>
        Task<int> CountAsync(Expression<Func<TAggregateRoot, bool>> predicate);

        /// <summary>
        /// 获取满足筛选条件的聚合实体数量
        /// </summary>
        /// <param name="specification">规约</param>
        /// <returns>聚合实体数量</returns>
        int Count(ISpecification<TAggregateRoot> specification);

        /// <summary>
        /// 获取满足筛选条件的聚合实体数量
        /// </summary>
        /// <param name="specification">规约</param>
        /// <returns>聚合实体数量</returns>
        Task<int> CountAsync(ISpecification<TAggregateRoot> specification);

        #endregion
    }
}
