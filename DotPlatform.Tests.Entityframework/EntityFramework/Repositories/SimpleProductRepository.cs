using DotPlatform.EntityFramework;
using DotPlatform.EntityFramework.Repositories;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.Tests.Entityframework.Repositories;

namespace DotPlatform.Tests.EntityFramework.Repositories
{
    public class SimpleProductRepository : EfRepository<TestEfDbContext, Product>, ISimpleProductRepository
    {
        public SimpleProductRepository(IDbContextProvider<TestEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
            
        }
    }
}
