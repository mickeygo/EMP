using DotPlatform.Configuration.Fluent.Config;

namespace DotPlatform.Configuration.Fluent
{
    /// <summary>
    /// 缓存 Cache Fluent 配置
    /// </summary>
    public class CacheFluentConfigurator : ConfiguratorBase<CacheSectionConfiguration>
    {
        /// <summary>
        /// 初始化一个<see cref="CacheFluentConfigurator"/>实例
        /// </summary>
        public CacheFluentConfigurator() : base("dotPlatformCache")
        {
        }
    }
}
