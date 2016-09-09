using System.Data.Entity;
using DotPlatform.EntityFramework;
using DotPlatform.Runtime.Session;
using System.Reflection;

namespace DotPlatform.Tests.SampleApplication.EntityFramework
{
    /// <summary>
    /// 示例上下文
    /// </summary>
    public class SampleDbContext : EfDbContext
    {
        public SampleDbContext() : base("MyTest")
        {
            this.OwnerSession = NullSession.Instance;
        }

        protected override void CreateModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
