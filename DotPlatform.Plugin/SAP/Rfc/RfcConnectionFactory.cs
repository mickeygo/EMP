using DotPlatform.Plugin.SAP.Rfc.Plain;
using DotPlatform.Utils;

namespace DotPlatform.Plugin.SAP.Rfc
{
    /// <summary>
    /// Rfc 连接工厂
    /// </summary>
    public static class RfcConnectionFactory
    {
        /// <summary>
        /// 基于 Plain 的 Rfc
        /// </summary>
        public static class Plain
        {
            /// <summary>
            /// 创建 Rfc 连接
            /// </summary>
            /// <param name="nameOrConnectionString">基于 config 的连接名或是连接字符串</param>
            /// <returns></returns>
            public static IRfcConnection Create(string nameOrConnectionString)
            {
                var connectionString = ConfigurationHelper.TryGetValueFromAppSetting(nameOrConnectionString);
                return new PlainRfcConnection(connectionString ?? nameOrConnectionString);
            }
        }
    }
}
