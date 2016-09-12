using System.Data.Entity;
using System.Reflection;
using DotPlatform.EntityFramework;

namespace DotPlatform.RBAC.Repository
{
    /// <summary>
    /// Rbac DB 上下文。基于 Microsoft EntityFramework 框架。
    /// </summary>
    public class RbacEfDbContext : EfDbContext
    {
        public RbacEfDbContext() : base(ConnectionName)
        {
            
        }

        protected override void CreateModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        #region

        /// <summary>
        /// 获取 DB 上下文连接字符串名称
        /// </summary>
        public static string ConnectionName
        {
            get { return GetRealConnectionName("RBAC"); }
        }

        #endregion

        #region Private Methods

        private static string GetRealConnectionName(string name)
        {
#if DEBUG
            return name + "Debug";
#else
            return name;
#endif
        }

        #endregion
    }
}
