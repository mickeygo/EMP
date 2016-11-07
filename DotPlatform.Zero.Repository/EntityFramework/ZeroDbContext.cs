using System.Data.Entity;
using System.Reflection;
using DotPlatform.EntityFramework;

namespace DotPlatform.Zero.Repository.EntityFramework
{
    /// <summary>
    /// 基于 Zero 模块的 DB 上下文
    /// </summary>
    public class ZeroDbContext : EfDbContext
    {
        public ZeroDbContext() : base(DbConnectionHelper.ConnectionName("Zero"))
        {

        }

        protected override void CreateModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
