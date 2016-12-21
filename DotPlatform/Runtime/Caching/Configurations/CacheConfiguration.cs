using System;
using System.Collections.Generic;

namespace DotPlatform.Runtime.Caching.Configurations
{
    /// <summary>
    /// 缓存配置类。
    /// 其中包含多个<see cref="ICacheConfigurator"/>缓存配置程序
    /// </summary>
    internal class CacheConfiguration : ICacheConfiguration
    {
        private readonly List<ICacheConfigurator> _configurators = new List<ICacheConfigurator>();

        public IReadOnlyList<ICacheConfigurator> Configurators
        {
            get { return _configurators; }
        }

        public void Configure(string cacheName, TimeSpan defaultSlidingExpireTime)
        {
            _configurators.Add(new CacheConfigurator(cacheName, defaultSlidingExpireTime));
        }
    }
}
