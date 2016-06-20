using System.Transactions;

namespace DotPlatform.Domain.Uow
{
    /// <summary>
    /// 表示实现此接口的类为工作单元管理类。
    /// </summary>
    public interface IUnitOfWorkManager
    {
        /// <summary>
        /// 获取当前正处于激活状态的工作单元。
        /// 若不存在，则返回 null
        /// </summary>
        IActiveUnitOfWork Current { get; }

        /// <summary>
        /// 开始一个工作单元
        /// </summary>
        /// <returns>用于提交工作单元的处理者对象</returns>
        IUnitOfWorkCompleteHandle Begin();

        /// <summary>
        /// 开始一个工作单元
        /// </summary>
        /// <param name="scope">事务 Scope</param>
        /// <returns>用于提交工作单元的处理者对象</returns>
        IUnitOfWorkCompleteHandle Begin(TransactionScopeOption scope);

        /// <summary>
        ///  开始一个工作单元
        /// </summary>
        /// <param name="options">工作单元配置选项</param>
        /// <returns>用于提交工作单元的处理者对象</returns>
        IUnitOfWorkCompleteHandle Begin(UnitOfWorkOptions options);
    }
}
