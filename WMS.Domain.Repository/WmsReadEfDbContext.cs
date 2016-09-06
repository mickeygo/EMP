using System.Reflection;
using System.Data.Entity;
using DotPlatform.EntityFramework;
using DotPlatform.Runtime.Session;

namespace WMS.Domain.Repository
{
    /// <summary>
    /// 基于 Microsoft EntityFramework 的 DB 上下文.
    /// 只用于 ReadOnly.
    /// </summary>
    public class WmsReadEfDbContext : EfDbContext
    {
        public WmsReadEfDbContext() : base(ConnectionName)
        {
            this.OwnerSession = ClaimsSession.Instance;
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
            get { return GetRealConnectionName("WMS"); }
        }

        #endregion

        #region Private Methods

        private static string GetRealConnectionName(string name)
        {
#if DEBUG
            return name + "Debug";
#else
            return name + "Read";
#endif
        }

        #endregion
    }
}
