using DotPlatform.Dependency;

namespace DotPlatform.Runtime.Caching.Redis
{
    /// <summary>
    /// Redis Cache 启动项扩展
    /// </summary>
    public static class RedisBootstrapperExtensions
    {
        /// <summary>
        /// 使用 Redis Cache
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IBootstrapper UseRedisCache(this IBootstrapper app)
        {
            IocManager.Instance.Register<RedisCache>();
            IocManager.Instance.Register<IRedisCacheDatabaseProvider, RedisCacheDatabaseProvider>();
            IocManager.Instance.Register<ICacheManager, RedisCacheManager>();
            IocManager.Instance.Build();

            return app;
        }
    }
}
