using System;
using System.Data.Entity;
using DotPlatform.Domain.Uow;

namespace DotPlatform.EntityFramework.Uow
{
    /// <summary>
    /// Db 上下文提供者。
    /// 此对象用于 Uow，会提供当前的 DB 上下文
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public class UnitOfWorkDbContextProvider<TDbContext> : IDbContextProvider<TDbContext>
        where TDbContext : DbContext
    {
        private readonly ICurrentUnitOfWorkProvider _currentUnitOfWorkProvider;

        public UnitOfWorkDbContextProvider(ICurrentUnitOfWorkProvider currentUnitOfWorkProvider)
        {
            _currentUnitOfWorkProvider = currentUnitOfWorkProvider;
        }

        public TDbContext DbContext
        {
            get { return GetDbContext(); }
        }

        private TDbContext GetDbContext()
        {
            var efUow = _currentUnitOfWorkProvider.Current as EfUnitOfWork;
            if (efUow == null)
                throw new InvalidOperationException("UnitOfWork is not type of EfUnitOfWork unitOfWork");

            return efUow.GetOrCreateDbContext<TDbContext>();
        }
    }
}
