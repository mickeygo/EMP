using DotPlatform.EntityFramework;
using DotPlatform.EntityFramework.Repositories;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.TestBase.Repositores.Query;
using DotPlatform.Tests.SampleApplication.EntityFramework;

namespace DotPlatform.Tests.SampleApplication.Repositories.Query
{
    /// <summary>
    /// 示例产品仓储
    /// </summary>
    public class SampleProductQueryRepository : EfRepository<SampleDbContext, Product>, IProductQueryRepository
    {
        public SampleProductQueryRepository(ISimpleDbContextProvider<SampleDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
