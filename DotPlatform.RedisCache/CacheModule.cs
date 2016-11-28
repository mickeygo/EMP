using DotPlatform.Modules;
using DotPlatform.RedisCache.Runtime.Caching.Redis;
using DotPlatform.Runtime.Caching;

namespace DotPlatform.RedisCache
{
    /// <summary>
    /// 缓存模块
    /// </summary>
    [DependsOn]
    public class CacheModule : ModuleBase
    {
        public override void PreInitialize()
        {
            IocManager.Register<Runtime.Caching.Redis.RedisCache>();
            IocManager.Register<IRedisCacheDatabaseProvider, RedisCacheDatabaseProvider>();
            IocManager.Register<ICacheManager, RedisCacheManager>();

            base.PreInitialize();
        }
    }
}
