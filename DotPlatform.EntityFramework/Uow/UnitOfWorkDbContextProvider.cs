using System;
using System.Data.Entity;

namespace DotPlatform.EntityFramework.Uow
{
    public class UnitOfWorkDbContextProvider<TDbContext> : IDbContextProvider<TDbContext>
        where TDbContext : DbContext
    {
        public TDbContext DbContext
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
