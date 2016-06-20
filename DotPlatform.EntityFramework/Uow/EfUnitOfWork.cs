using System;
using System.Collections.Concurrent;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using DotPlatform.Domain.Uow;

namespace DotPlatform.EntityFramework.Uow
{
    /// <summary>
    /// 表示用于 Microsoft EntityFramework 的工作单元
    /// </summary>
    public class EfUnitOfWork : UnitOfWorkBase
    {
        private readonly ConcurrentDictionary<Type, DbContext> _activeDbContexts = new ConcurrentDictionary<Type, DbContext>();
        private TransactionScope _currentTransaction;

        public override void SaveChanges()
        {
            this._activeDbContexts.Values.ToList().ForEach(context =>
            {
                context.SaveChanges();
            });
        }

        public override async Task SaveChangesAsync()
        {
            foreach (var context in _activeDbContexts.Values)
            {
                await context.SaveChangesAsync();
            }
        }

        protected override void BeginUow()
        {
            if (!this.Options.IsTransactional == false)
            {
                return;
            }

            _currentTransaction = new TransactionScope();
        }

        protected override void CompleteUow()
        {
            SaveChanges();

            if (this._currentTransaction != null)
            {
                this._currentTransaction.Complete();
            }
        }

        protected override async Task CompleteUowAsync()
        {
            await SaveChangesAsync();

            if (this._currentTransaction != null)
            {
                this._currentTransaction.Complete();
            }
        }

        protected override void DisposeUow()
        {
            this._activeDbContexts.Values.ToList().ForEach(context =>
            {
                context.Dispose();
            });

            if (this._currentTransaction != null)
            {
                this._currentTransaction.Dispose();
            }
        }
    }
}
