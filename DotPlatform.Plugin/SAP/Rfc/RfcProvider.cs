using SAP.Middleware.Connector;

namespace DotPlatform.Plugin.SAP.Rfc
{
    /// <summary>
    /// Rfc 提供者
    /// </summary>
    internal class RfcProvider : IRfcProvider
    {
        public RfcDestination Rfc { get; }

        public RfcProvider(RfcDestination rfc)
        {
            Rfc = rfc;
        }
    }
}
