namespace DotPlatform.Utils
{
    /// <summary>
    /// 基于 app /web config 配置文件的辅助类
    /// </summary>
    public static class ConfigurationHelper
    {
        /// <summary>
        /// 尝试从 appSettings 中获取节点值。若不存在，返回 null.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string TryGetValueFromAppSetting(string name)
        {
            try
            {
                return System.Configuration.ConfigurationManager.AppSettings[name];
            }
            catch
            {
                return null;
            }
        }
    }
}
