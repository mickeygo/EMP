using System;
using System.Runtime.Serialization;

namespace DotPlatform
{
    /// <summary>
    /// DotPlatform 基础框架异常类
    /// </summary>
    public class DotPlatformException : Exception
    {
        /// <summary>
        /// 初始化一个新的<c>DotPlatformException</c>>实例
        /// </summary>
        public DotPlatformException()
        {
            
        }

        /// <summary>
        /// 初始化一个新的<c>DotPlatformException</c>>实例
        /// </summary>
        public DotPlatformException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
            
        }

        /// <summary>
        /// 初始化一个新的<c>DotPlatformException</c>>实例
        /// </summary>
        /// <param name="message">异常消息</param>
        public DotPlatformException(string message)
            : base(message)
        {
            
        }

        /// <summary>
        /// 初始化一个新的<c>DotPlatformException</c>>实例
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="innerException">内部异常</param>
        public DotPlatformException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
