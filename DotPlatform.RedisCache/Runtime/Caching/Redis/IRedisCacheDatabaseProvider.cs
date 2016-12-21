using StackExchange.Redis;

namespace DotPlatform.Runtime.Caching.Redis
{
    /// <summary>
    /// 表示实现此接口的类为 Redis 缓存 Database 提供者
    /// </summary>
    public interface IRedisCacheDatabaseProvider
    {
        IDatabase GetDatabase();
    }
}
