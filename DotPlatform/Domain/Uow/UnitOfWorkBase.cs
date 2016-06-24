using System;
using System.Threading.Tasks;

namespace DotPlatform.Domain.Uow
{
    /// <summary>
    /// 工作单元基类。
    /// </summary>
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        #region Fields

        private bool _isCompletedOK;
        private Exception _exception;
        private readonly IUnitOfWorkDefaultOptions _defaultOptions;

        #endregion

        #region Ctor

        protected UnitOfWorkBase(IUnitOfWorkDefaultOptions options)
        {
            this._defaultOptions = options;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 获取工作单元配置项
        /// </summary>
        public UnitOfWorkOptions Options { get; private set; }

        #region IActiveUnitOfWork Members

        public event EventHandler Completed;

        public event EventHandler<UnitOfWorkFailedEventArgs> Failed;

        public event EventHandler Disposed;

        public bool IsDisposed { get; private set; }

        public abstract void SaveChanges();

        public abstract Task SaveChangesAsync();

        #endregion

        #endregion

        #region IUnitOfWorkCompleteHandle Members

        public void Complete()
        {
            try
            {
                this.CompleteUow();
                this._isCompletedOK = true;
                this.OnCompleted();
            }
            catch (Exception ex)
            {
                this._exception = ex;
                throw;
            }
        }

        public async Task CompleteAsync()
        {
            try
            {
                await this.CompleteUowAsync();
                this._isCompletedOK = true;
                this.OnCompleted();
            }
            catch (Exception ex)
            {
                this._exception = ex;
                throw;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }
            this.IsDisposed = true;

            if (!this._isCompletedOK)
            {
                this.OnFailed(this._exception);
            }

            this.DisposeUow();
            this.OnDisposed();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// 调用<see cref="Completed"/>事件
        /// </summary>
        protected void OnCompleted()
        {
            if (this.Completed != null)
            {
                this.Completed(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 调用<see cref="Failed"/>事件
        /// </summary>
        /// <param name="ex">异常信息</param>
        protected void OnFailed(Exception ex)
        {
            if (this.Failed != null)
            {
                this.Failed(this, new UnitOfWorkFailedEventArgs(ex));
            }
        }

        /// <summary>
        /// 调用<see cref="Disposed"/>事件
        /// </summary>
        protected void OnDisposed()
        {
            if (this.Disposed != null)
            {
                this.Disposed(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 开始调用工作单元
        /// </summary>
        protected abstract void BeginUow();

        /// <summary>
        /// 完成工作单元
        /// </summary>
        protected abstract void CompleteUow();

        /// <summary>
        /// 完成工作单元
        /// </summary>
        /// <returns></returns>
        protected abstract Task CompleteUowAsync();

        /// <summary>
        /// 释放工作单元
        /// </summary>
        protected abstract void DisposeUow();

        #endregion

        #region Privaite Methods

        #endregion

        #region IUnitOfWork Members

        public void Begin(UnitOfWorkOptions options)
        {
            this.Options = options;
            options.SetDefaultOptions(_defaultOptions);

            BeginUow();
        }

        #endregion
    }
}
