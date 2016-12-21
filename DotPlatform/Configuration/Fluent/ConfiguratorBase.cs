using System;
using System.Configuration;
using DotPlatform.Loggers;

namespace DotPlatform.Configuration.Fluent
{
    /// <summary>
    /// 配置基类
    /// </summary>
    /// <typeparam name="T">要配置的节点类型</typeparam>
    public class ConfiguratorBase<T> : ConfigurationSection
        where T : ConfigurationSection, new()
    {
        private readonly string _setion;

        /// <summary>
        /// 获取 SectionGroup 的名称, 默认为 dotPlatform
        /// </summary>
        public string SectionGroupName { get; protected set; } = "dotPlatform";

        protected ConfiguratorBase(string section)
        {
            this._setion = section;
        }

        /// <summary>
        /// 获取配置对象实例.
        /// 若配置不存在，会返回 null.
        /// </summary>
        /// <returns></returns>
        public T GetConfiguration()
        {
            try
            {
                var sectionName = $"{SectionGroupName}/{this._setion}";
                return (T)ConfigurationManager.GetSection(sectionName);
            }
            catch (Exception ex)
            {
                // Suppress error
                LoggerFactory.Logger.Error($"Get the [{SectionGroupName}/{this._setion}] configuration section error.", ex);
            }

            return default(T);
        }
    }
}
