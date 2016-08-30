using System.Data.Entity;
using System.Reflection;
using DotPlatform.EntityFramework;
using DotPlatform.Runtime.Session;

namespace DotPlatform.RBAC.Repository
{
    /// <summary>
    /// 基于 Microsoft EntityFramework 的 RBAC DB 上下文
    /// </summary>
    public class RbacEfDbContext : EfDbContext
    {
        public RbacEfDbContext() : base(ConnectionName)
        {
            // Todo: change the RbacEfDbContext Session
            OwnerSession = NullSession.Instance;
        }

        protected override void CreateModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(this.GetType()));
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
