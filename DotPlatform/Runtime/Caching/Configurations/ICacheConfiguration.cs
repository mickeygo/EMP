﻿using System.Collections.Generic;

namespace DotPlatform.Runtime.Caching.Configurations
{
    /// <summary>
    /// 表示实现此接口的对象为缓存配置类
    /// </summary>
    public interface ICacheConfiguration
    {
        IReadOnlyList<ICacheConfigurator> Configurators { get; }
    }
}
