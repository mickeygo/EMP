using DotPlatform.EntityFramework.Repositories;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.EntityFramework;

namespace DotPlatform.Tests.EntityFramework.Repositories
{
    public class OrderRepository : EfRepository<TestEfDbContext, Order>
    {
        public OrderRepository() : base(new UnitOfWorkDbContextProvider<TestEfDbContext>(new TestEfDbContext()))
        {
            
        }
    }
}
