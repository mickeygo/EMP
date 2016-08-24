using DotPlatform.EntityFramework;
using DotPlatform.EntityFramework.Repositories;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.TestBase.Repositores;
using DotPlatform.Tests.SampleApplication.EntityFramework;

namespace DotPlatform.Tests.SampleApplication.Repositories
{
    /// <summary>
    /// 示例产品仓储
    /// </summary>
    public class SampleProductRepository : EfRepository<SampleDbContext, Product>, IProductRepository
    {
        public SampleProductRepository(IDbContextProvider<SampleDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
