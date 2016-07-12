using DotPlatform.EntityFramework;
using DotPlatform.EntityFramework.Repositories;
using DotPlatform.TestBase.Domain.Entities;

namespace DotPlatform.Tests.EntityFramework.Repositories
{
    public class ProductRepository : EfRepository<TestEfDbContext, Product>
    {
        public ProductRepository() : base(new SimpleDbContextProvider<TestEfDbContext>(new TestEfDbContext()))
        {

        }
    }
}
