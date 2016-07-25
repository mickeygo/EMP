using System.Data.Entity;

namespace DotPlatform.EntityFramework
{
    /// <summary>
    /// DB 上下文提供者。做了简单的封装。
    /// 使用简单的 DB 上下文提供对象，DB 上下文对象 直接从 <see cref="TDbContext"/> 解析出来（必须在 IoC 中有注入），
    /// 然后给仓储对象<see cref="EfRepository{TDbContext}"/>
    /// </summary>
    /// <typeparam name="TDbContext">派生于<see cref="DbContext"/>的上下文对象</typeparam>
    public class SimpleDbContextProvider<TDbContext> : IDbContextProvider<TDbContext>
      where TDbContext : DbContext
    {
        /// <summary>
        /// 获取 DB 上下文
        /// </summary>
        public TDbContext DbContext { get; private set; }

        /// <summary>
        /// 初始化一个新的<c>SimpleDbContextProvider</c>对象.
        /// 使用 Func<TDbContext> 参数效果等同，但都必须先将 TDbContext 对象在 IOC 中注册
        /// </summary>
        public SimpleDbContextProvider(TDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
    }
}
