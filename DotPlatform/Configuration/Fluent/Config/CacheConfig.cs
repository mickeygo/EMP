using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DotPlatform.Configuration.Fluent.Config
{
    /// <summary>
    /// 缓存节点配置
    /// </summary>
    public class CacheSectionConfiguration : ConfigurationSection
    {
        #region Properties

        internal const string CachePropertyName = "caches";

        #endregion

        #region Public Properties

        /// <summary>
        /// 获取或设置缓存配置元素，元素节点名为 dotPlatformCache
        /// </summary>
        [ConfigurationProperty(CachePropertyName, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(CacheElementConfigurationCollection), AddItemName = "add")]
        public CacheElementConfigurationCollection CacheElementCollection
        {
            get { return (CacheElementConfigurationCollection)this[CachePropertyName]; }
            set { this[CachePropertyName] = value; }
        }

        #endregion
    }

    /// <summary>
    /// 缓存元素集合
    /// </summary>
    public class CacheElementConfigurationCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CacheElementConfiguration();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CacheElementConfiguration)element).CacheName;
        }

        public IEnumerable<string> GetAllKeys
        {
            get { return BaseGetAllKeys().Cast<string>(); }
        }

        public new CacheElementConfiguration this[string name]
        {
            get { return (CacheElementConfiguration)BaseGet(name); }
        }
    }

    /// <summary>
    /// 缓存配置节点元素
    /// </summary>
    public class CacheElementConfiguration : ConfigurationElement
    {
        #region Properties

        internal const string CacheNamePropertyName = "name";
        internal const string AbsoluteExpirationPropertyName = "absoluteExpiration";
        internal const string SlidingExpirationPropertyName = "slidingExpiration";

        #endregion

        #region Public Properties

        /// <summary>
        /// 获取或设置缓存的名称
        /// </summary>
        [ConfigurationProperty(CacheNamePropertyName, DefaultValue = "", IsRequired = true, IsKey = true)]
        public string CacheName
        {
            get { return (string)this[CacheNamePropertyName]; }
            set { this[CacheNamePropertyName] = value; }
        }

        /// <summary>
        /// 获取或设置缓存的绝对过期时间（分钟）
        /// </summary>
        [ConfigurationProperty(AbsoluteExpirationPropertyName, DefaultValue = 0, IsRequired = false, IsKey = false)]
        [IntegerValidator(ExcludeRange = false, MinValue = 0)]
        public int AbsoluteExpiration
        {
            get { return (int)this[AbsoluteExpirationPropertyName]; }
            set { this[AbsoluteExpirationPropertyName] = value; }
        }

        /// <summary>
        /// 获取或设置缓存的相对过期时间（分钟）
        /// </summary>
        [ConfigurationProperty(SlidingExpirationPropertyName, DefaultValue = 0, IsRequired = false, IsKey = false)]
        [IntegerValidator(ExcludeRange = false, MinValue = 0)]
        public int SlidingExpiration
        {
            get { return (int)this[SlidingExpirationPropertyName]; }
            set { this[SlidingExpirationPropertyName] = value; }
        }

        #endregion
    }
}
