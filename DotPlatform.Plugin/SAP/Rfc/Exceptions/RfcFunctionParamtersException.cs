using System;

namespace DotPlatform.Plugin.SAP.Rfc.Exceptions
{
    /// <summary>
    /// RFC 函数参数异常
    /// </summary>
    public class RfcFunctionParamtersException : DotPlatformException
    {
        public RfcFunctionParamtersException(string message) : base(message)
        {
        }

        public RfcFunctionParamtersException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
