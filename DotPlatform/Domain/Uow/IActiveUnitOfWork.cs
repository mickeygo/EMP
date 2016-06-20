using System;
using System.Threading.Tasks;

namespace DotPlatform.Domain.Uow
{
    /// <summary>
    /// 处于激活状态的工作单元
    /// </summary>
    public interface IActiveUnitOfWork
    {
        /// <summary>
        /// 当工作单元成功执行后引发事件
        /// </summary>
        event EventHandler Completed;

        /// <summary>
        /// 当工作单元执行失败后引发事件
        /// </summary>
        event EventHandler<UnitOfWorkFailedEventArgs> Failed;

        /// <summary>
        /// 当工作单元 Dispose 后引发事件
        /// </summary>
        event EventHandler Disposed;

        /// <summary>
        /// 获取一个<see cref="System.Boolean"/>值，指示工作单元是否与释放
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// 保存所有的变更。
        /// 若引用了事务，若事务回滚，所有的变更也会回滚。
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// 保存所有的变更。
        /// 若引用了事务，若事务回滚，所有的变更也会回滚。
        /// </summary>
        Task SaveChangesAsync();
    }
}
