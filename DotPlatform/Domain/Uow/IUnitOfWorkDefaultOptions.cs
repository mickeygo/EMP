using System;
using System.Transactions;

namespace DotPlatform.Domain.Uow
{
    /// <summary>
    /// 表示实现此接口的类为默认的工作单元选项
    /// </summary>
    public interface IUnitOfWorkDefaultOptions
    {
        /// <summary>
        /// 获取或设置事务范围
        /// </summary>
        TransactionScopeOption Scope { get; set; }

        /// <summary>
        /// 获取或设置一个值，用于指定工作单元是否是事务级别
        /// </summary>
        bool IsTransactional { get; set; }

        /// <summary>
        /// 获取或设置超时时间
        /// </summary>
        TimeSpan? Timeout { get; set; }

        /// <summary>
        /// 获取或设置事务隔离级别
        /// </summary>
        IsolationLevel? IsolationLevel { get; set; }
    }
}
