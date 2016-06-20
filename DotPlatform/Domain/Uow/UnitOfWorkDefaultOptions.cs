using System;
using System.Transactions;

namespace DotPlatform.Domain.Uow
{
    /// <summary>
    /// 默认的工作单元选项
    /// </summary>
    public class UnitOfWorkDefaultOptions : IUnitOfWorkDefaultOptions
    {
        #region IUnitOfWorkDefaultOptions Members

        public TransactionScopeOption Scope { get; set; }

        public bool IsTransactional { get; set; }

        public TimeSpan? Timeout { get; set; }

        public IsolationLevel? IsolationLevel { get; set; }

        #endregion

        /// <summary>
        /// 初初始化一个新的<c>UnitOfWorkDefaultOptions</c>实例
        /// </summary>
        public UnitOfWorkDefaultOptions()
        {
            Scope = TransactionScopeOption.Required;
            IsTransactional = true;
        }
    }
}
