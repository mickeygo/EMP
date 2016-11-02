using System;

namespace DotPlatform.Plugin.SAP.Rfc.Exceptions
{
    /// <summary>
    /// RFC 连接异常
    /// </summary>
    public class RfcConnectionException : DotPlatformException
    {
        public RfcConnectionException(string message) : base(message)
        {
        }

        public RfcConnectionException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
