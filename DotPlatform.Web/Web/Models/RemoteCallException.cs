using System;
using System.Runtime.Serialization;

namespace DotPlatform.Web.Models
{
    /// <summary>
    /// 远程调用异常
    /// </summary>
    [Serializable]
    public class RemoteCallException : DotPlatformException
    {
        /// <summary>
        /// 获取或设置远程调用时出现的错误信息
        /// </summary>
        public ErrorInfo ErrorInfo { get; set; }

        /// <summary>
        /// 初始化一个新的<see cref="DotPlatformException"/>实例
        /// </summary>
        public RemoteCallException()
        {

        }

        /// <summary>
        /// 初始化一个新的<see cref="DotPlatformException"/>实例
        /// </summary>
        public RemoteCallException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// 初始化一个新的<see cref="DotPlatformException"/>实例
        /// </summary>
        /// <param name="errorInfo">异常信息</param>
        public RemoteCallException(ErrorInfo errorInfo)
            : base(errorInfo.Message)
        {
            ErrorInfo = errorInfo;
        }
    }
}
