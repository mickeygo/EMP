using System.Data.Entity;

namespace DotPlatform.EntityFramework
{
    /// <summary>
    /// 简单的 DbContext 上下文调用者。
    /// 用于直接对 DbContext 进行调用。
    /// </summary>
    /// <typeparam name="TDbContext"><see cref="DbContext"/></typeparam>
    public interface ISimpleDbContextProvider<out TDbContext> : IDbContextProvider<TDbContext>
         where TDbContext : DbContext
    {
    }
}
