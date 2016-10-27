using System;

namespace DotPlatform.Plugin.SAP.Rfc.Exceptions
{
    /// <summary>
    /// 未知的 RFC 参数异常
    /// </summary>
    public class UnknownRfcParameterException : DotPlatformException
    {
        public UnknownRfcParameterException(string message) : base(message)
        {

        }

        public UnknownRfcParameterException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
