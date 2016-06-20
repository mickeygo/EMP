using System;
using System.Transactions;

namespace DotPlatform.Domain.Uow
{
    /// <summary>
    /// 工作单元选项
    /// </summary>
    public class UnitOfWorkOptions
    {
        #region Public Properties

        /// <summary>
        /// 获取或设置事务范围
        /// </summary>
        public TransactionScopeOption? Scope { get; set; }

        /// <summary>
        /// 获取或设置一个值，用于指定工作单元是否是事务级别
        /// </summary>
        public bool? IsTransactional { get; set; }

        /// <summary>
        /// 获取或设置超时时间
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// 获取或设置事务隔离级别
        /// </summary>
        public IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// 获取或设置一个值，是否支持跨线程的连续事务流
        /// </summary>
        public TransactionScopeAsyncFlowOption? AsyncFlowOption { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// 设置默认的工作单元配置选项
        /// </summary>
        /// <param name="options">工作单元配置选项</param>
        internal void SetDefaultOptions(IUnitOfWorkDefaultOptions options)
        {
            if (!this.Scope.HasValue)
                this.Scope = options.Scope;

            if (!this.IsTransactional.HasValue)
                this.IsTransactional = options.IsTransactional;

            if (!this.Timeout.HasValue && options.Timeout.HasValue)
                this.Timeout = options.Timeout;

            if (!this.IsolationLevel.HasValue && options.IsolationLevel.HasValue)
                this.IsolationLevel = options.IsolationLevel;
        }

        #endregion
    }
}
