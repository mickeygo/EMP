using DotPlatform.EntityFramework;
using DotPlatform.EntityFramework.Repositories;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.Tests.EntityFramework;

namespace DotPlatform.Tests.Entityframework.Repositories
{
    public class UpdateProductAppService : EfRepository<TestEfDbContext2, Product>, ICallContextProductRepository2
    {
        public readonly IDbContextProvider<TestEfDbContext2> _dbContextProvider;

        public UpdateProductAppService(IDbContextProvider<TestEfDbContext2> dbContextProvider) : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }
    }
}
