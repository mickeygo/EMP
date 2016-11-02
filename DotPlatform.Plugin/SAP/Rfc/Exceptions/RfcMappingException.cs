using System;

namespace DotPlatform.Plugin.SAP.Rfc.Exceptions
{
    /// <summary>
    /// RFC 对象映射异常
    /// </summary>
    public class RfcMappingException : DotPlatformException
    {
        public RfcMappingException(string message) : base(message)
        {
        }

        public RfcMappingException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
