using System.Threading.Tasks;
using DotPlatform.Domain.Entities;

namespace DotPlatform.Domain.Repositories
{
    /// <summary>
    /// 表示实现此接口类为仓储对象,用于聚合Command <see cref="IRepository{TAggregateRoot,TKey}"/>
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合根类型，<see cref="IAggregateRoot"/></typeparam>
    /// <typeparam name="TKey">聚合根主键</typeparam>
    public interface ICommandRepository<TAggregateRoot, TKey>
         where TAggregateRoot : IAggregateRoot<TKey>
    {
        #region Add

        /// <summary>
        /// 添加一个新的聚合根
        /// </summary>
        /// <param name="aggregate">要添加的聚合根</param>
        /// <returns>已添加的聚合根</returns>
        TAggregateRoot Add(TAggregateRoot aggregate);

        /// <summary>
        /// 添加一个新的聚合根
        /// </summary>
        /// <param name="aggregate">要添加的聚合根</param>
        /// <returns>已添加的聚合根</returns>
        Task<TAggregateRoot> AddAsync(TAggregateRoot aggregate);

        #endregion

        #region Update

        /// <summary>
        /// 更新一个聚合根
        /// </summary>
        /// <param name="aggregate">要更新的聚合根</param>
        /// <returns>已更新的聚合根</returns>
        TAggregateRoot Update(TAggregateRoot aggregate);

        /// <summary>
        /// 更新一个聚合根
        /// </summary>
        /// <param name="aggregate">要更新的聚合根</param>
        /// <returns>已更新的聚合根</returns>
        Task<TAggregateRoot> UpdateAsync(TAggregateRoot aggregate);

        #endregion

        #region Delete

        /// <summary>
        /// 删除一个聚合根
        /// </summary>
        /// <param name="aggregate">要删除的聚合根</param>
        void Delete(TAggregateRoot aggregate);

        /// <summary>
        /// 删除一个聚合根
        /// </summary>
        /// <param name="aggregate">要删除的聚合根</param>
        Task DeleteAsync(TAggregateRoot aggregate);

        /// <summary>
        /// 删除一个聚合根
        /// </summary>
        /// <param name="id">要删除的聚合根 Id</param>
        void Delete(TKey id);

        /// <summary>
        /// 删除一个聚合根
        /// </summary>
        /// <param name="id">要删除的聚合根 Id</param>
        Task DeleteAsync(TKey id);

        #endregion
    }
}
