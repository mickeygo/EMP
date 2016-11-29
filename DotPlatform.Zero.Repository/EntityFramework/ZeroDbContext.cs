using System.Data.Entity;
using System.Reflection;
using System.Threading.Tasks;
using DotPlatform.EntityFramework;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Repository.EntityFramework
{
    /// <summary>
    /// 基于 Zero 模块的 DB 上下文
    /// </summary>
    public class ZeroDbContext : EfDbContext
    {
        public ZeroDbContext() : base(DbConnectionHelper.ConnectionName("Zero"))
        {
            //Configuration.AutoDetectChangesEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
        }

        protected override void CreateModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
