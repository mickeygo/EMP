using DotPlatform.EntityFramework;
using DotPlatform.EntityFramework.Repositories;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.Tests.EntityFramework;

namespace DotPlatform.Tests.Entityframework.Repositories
{
    public class CallContextProductRepository : EfRepository<TestEfDbContext, Product>, ICallContextProductRepository
    {
        public readonly IDbContextProvider<TestEfDbContext> _dbContextProvider;

        public CallContextProductRepository(IDbContextProvider<TestEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }
    }
}
