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
        private readonly ICurrentUnitOfWorkProvider _currentUnitOfWorkProvider;
        private readonly IUnitOfWorkDefaultOptions _unitOfWorkDefaultOptions;

        #region Ctor

        /// <summary>
        /// 初始化一个新的<c>UnitOfWorkManager</c>实例
        /// </summary>
        public UnitOfWorkManager(ICurrentUnitOfWorkProvider currentUnitOfWorkProvider,
            IUnitOfWorkDefaultOptions unitOfWorkDefaultOptions)
        {
            _iocResolver = IocManager.Instance;
            _currentUnitOfWorkProvider = currentUnitOfWorkProvider;
            _unitOfWorkDefaultOptions = unitOfWorkDefaultOptions;
        }

        #endregion

        #region IUnitOfWorkManager Members

        public IActiveUnitOfWork Current
        {
            get { return _currentUnitOfWorkProvider.Current; }
        }

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

            // 将多次定义的事务聚集在一起
            if (options.Scope == TransactionScopeOption.Required && _currentUnitOfWorkProvider.Current != null)
            {
                return new InnerUnitOfWorkCompleteHandle();
            }

            var uow = this._iocResolver.Resolve<IUnitOfWork>();

            // Must Set
            uow.Disposed += (s, e) =>
            {
                _currentUnitOfWorkProvider.Current = null; // 释放资源时，同时释放当前工作单元的数据槽
            };

            uow.Begin(options);

            _currentUnitOfWorkProvider.Current = uow;

            return uow;
        }

        #endregion
    }
}
