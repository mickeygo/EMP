using System;
using System.Collections.Concurrent;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using DotPlatform.Domain.Uow;
using DotPlatform.Dependency;

namespace DotPlatform.EntityFramework.Uow
{
    /// <summary>
    /// 表示用于 Microsoft EntityFramework 的工作单元
    /// </summary>
    public class EfUnitOfWork : UnitOfWorkBase
    {
        #region Fields

        private readonly ConcurrentDictionary<Type, DbContext> _activeDbContexts = new ConcurrentDictionary<Type, DbContext>();
        private TransactionScope _currentTransaction;
        private readonly IIocResolver _iocResolver;

        #endregion

        #region Ctor

        /// <summary>
        /// 初始化一个新的<c>EfUnitOfWork</c>实例
        /// </summary>
        public EfUnitOfWork(IIocResolver iocResolver, IUnitOfWorkDefaultOptions options) 
            : base(options)
        {
            this._iocResolver = iocResolver;
        }
       
        #endregion

        #region Public Methods

        /// <summary>
        /// override, 保存<see cref="DbContext"/>集已做的更改。在提交事务时会执行此方法.
        /// </summary>
        public override void SaveChanges()
        {
            this._activeDbContexts.Values.ToList().ForEach(context =>
            {
                context.SaveChanges();
            });
        }

        /// <summary>
        /// override, 保存<see cref="DbContext"/>集已做的更改。在提交事务时会执行此方法.
        /// </summary>
        public override async Task SaveChangesAsync()
        {
            foreach (var context in _activeDbContexts.Values)
            {
                await context.SaveChangesAsync();
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// override, 开始一个工作单元。此时启动 <see cref="TransactionScope"/> 事务
        /// </summary>
        protected override void BeginUow()
        {
            if (!this.Options.IsTransactional == false)
                return;

            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = Options.IsolationLevel.GetValueOrDefault(IsolationLevel.ReadUncommitted),
            };

            if (Options.Timeout.HasValue)
            {
                transactionOptions.Timeout = Options.Timeout.Value;
            }

            _currentTransaction = new TransactionScope(
                Options.Scope.GetValueOrDefault(TransactionScopeOption.Required),
                transactionOptions,
                Options.AsyncFlowOption.GetValueOrDefault(TransactionScopeAsyncFlowOption.Enabled)
            );
        }

        /// <summary>
        /// override, 保存当前所有的<see cref="DbContext"/>当前所做的更改，然后提交当前事务。
        /// </summary>
        protected override void CompleteUow()
        {
            SaveChanges();

            if (this._currentTransaction != null)
                this._currentTransaction.Complete();
        }

        /// <summary>
        /// override, 保存当前所有的<see cref="DbContext"/>当前所做的更改，然后提交当前事务。
        /// </summary>
        protected override async Task CompleteUowAsync()
        {
            await SaveChangesAsync();

            if (this._currentTransaction != null)
                this._currentTransaction.Complete();
        }

        /// <summary>
        /// override, 释放<see cref="DbContext"/>所占用的资源，并 Dispose 当前事务
        /// </summary>
        protected override void DisposeUow()
        {
            this._activeDbContexts.Values.ToList().ForEach(context =>
            {
                context.Dispose();
            });

            if (this._currentTransaction != null)
                this._currentTransaction.Dispose();
        }

        #endregion
    }
}
