using System.Transactions;
using DotPlatform.Dependency;

namespace DotPlatform.Domain.Uow
{
    /// <summary>
    /// 工作单元管理类
    /// </summary>
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private readonly IIocResolver _iocResolver;
        private readonly IUnitOfWorkDefaultOptions _unitOfWorkDefaultOptions;

        #region Ctor

        /// <summary>
        /// 初始化一个新的<c>UnitOfWorkManager</c>实例
        /// </summary>
        public UnitOfWorkManager(IUnitOfWorkDefaultOptions unitOfWorkDefaultOptions)
        {
            _iocResolver = IocManager.Instance;
            _unitOfWorkDefaultOptions = unitOfWorkDefaultOptions;
        }

        #endregion

        #region IUnitOfWorkManager Members

        public IActiveUnitOfWork Current { get; private set; }

        public IUnitOfWorkCompleteHandle Begin()
        {
            return this.Begin(new UnitOfWorkOptions());
        }

        public IUnitOfWorkCompleteHandle Begin(TransactionScopeOption scope)
        {
            return this.Begin(new UnitOfWorkOptions { Scope = scope });
        }

        public IUnitOfWorkCompleteHandle Begin(UnitOfWorkOptions options)
        {
            options.SetDefaultOptions(_unitOfWorkDefaultOptions);

            // Todo: 多个事务处理（如何将多次定义的事务聚集在一起）
            var uow = this._iocResolver.Resolve<IUnitOfWork>();

            uow.Completed += (s, e) =>
            {
                this.Current = null; 
            };

            uow.Failed += (s, e) =>
            {
                this.Current = null; 
            };

            uow.Begin(options);

            this.Current = uow;

            return uow;
        }

        #endregion
    }
}
