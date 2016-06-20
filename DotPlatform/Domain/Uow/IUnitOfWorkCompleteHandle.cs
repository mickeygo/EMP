using System;
using System.Threading.Tasks;

namespace DotPlatform.Domain.Uow
{
    /// <summary>
    /// 用于提交工作单元
    /// </summary>
    public interface IUnitOfWorkCompleteHandle : IDisposable
    {
        // Todo: 用 Commit / CommitAsync 代替 Complete / CompleteAsync

        /// <summary>
        /// 完成当前的工作单元。
        /// 会保存所有的变更并提交事务
        /// </summary>
        void Complete();

        /// <summary>
        /// 完成当前的工作单元。
        /// 会保存所有的变更并提交事务
        /// </summary>
        Task CompleteAsync();

        // Rollback()
    }
}
