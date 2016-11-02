using SAP.Middleware.Connector;

namespace DotPlatform.Plugin.SAP.Rfc
{
    /// <summary>
    /// Rfc 提供者
    /// </summary>
    public interface IRfcProvider
    {
        /// <summary>
        /// 获取 Rfc
        /// </summary>
        RfcDestination Rfc { get; }
    }
}
