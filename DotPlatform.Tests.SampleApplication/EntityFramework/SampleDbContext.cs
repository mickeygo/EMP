using System.Data.Entity;
using DotPlatform.EntityFramework;
using DotPlatform.Runtime.Session;
using System.Reflection;
using DotPlatform.Tests.SampleApplication.EntityFramework.EntityConfigurarion;

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
            //modelBuilder.Configurations.Add(new ProductEntityTypeConfuguration());
            //modelBuilder.Configurations.Add(new OrderEntityTypeConfuguration());
            //modelBuilder.Configurations.Add(new OrderLineEntityTypeConfuguration());

            //modelBuilder.Configurations.AddFromAssembly(Assembly.GetCallingAssembly());

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(this.GetType()));
        }
    }
}
