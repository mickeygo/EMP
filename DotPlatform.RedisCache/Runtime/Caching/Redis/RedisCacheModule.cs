using DotPlatform.Modules;

namespace DotPlatform.Runtime.Caching.Redis
{
    /// <summary>
    /// 缓存模块
    /// </summary>
    [DependsOn]
    internal class RedisCacheModule : ModuleBase
    {
        public override void PreInitialize()
        {
            IocManager.Register<RedisCache>();
            IocManager.Register<IRedisCacheDatabaseProvider, RedisCacheDatabaseProvider>();
            IocManager.Register<ICacheManager, RedisCacheManager>();

            base.PreInitialize();
        }
    }
}
