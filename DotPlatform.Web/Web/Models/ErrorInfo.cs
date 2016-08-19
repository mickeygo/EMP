using System;

namespace DotPlatform.Web.Models
{
    /// <summary>
    /// 用于存储错误信息
    /// </summary>
    [Serializable]
    public class ErrorInfo
    {
        #region Properties

        /// <summary>
        /// 获取或设置错误代码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 获取或设置错误信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Error details.
        /// 获取或设置详细的错误信息
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// 验证错误
        /// </summary>
        public ValidationErrorInfo[] ValidationErrors { get; set; }

        #endregion

        #region Ctor

        /// <summary>
        /// 初始化一个新的<see cref="ErrorInfo"/>对象
        /// </summary>
        public ErrorInfo()
        {

        }

        /// <summary>
        /// 初始化一个新的<see cref="ErrorInfo"/>对象
        /// </summary>
        /// <param name="message">错误信息</param>
        public ErrorInfo(string message)
        {
            Message = message;
        }

        /// <summary>
        /// 初始化一个新的<see cref="ErrorInfo"/>对象
        /// </summary>
        /// <param name="code">错误代码</param>
        public ErrorInfo(int code)
        {
            Code = code;
        }

        /// <summary>
        /// 初始化一个新的<see cref="ErrorInfo"/>对象
        /// </summary>
        /// <param name="code">错误代码</param>
        /// <param name="message">错误信息</param>
        public ErrorInfo(int code, string message)
            : this(message)
        {
            Code = code;
        }

        /// <summary>
        /// 初始化一个新的<see cref="ErrorInfo"/>对象
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="details">错误的明细信息</param>
        public ErrorInfo(string message, string details)
            : this(message)
        {
            Details = details;
        }

        /// <summary>
        /// 初始化一个新的<see cref="ErrorInfo"/>对象
        /// </summary>
        /// <param name="code">错误代码</param>
        /// <param name="message">错误信息</param>
        /// <param name="details">错误的明细信息</param>
        public ErrorInfo(int code, string message, string details)
            : this(message, details)
        {
            Code = code;
        }

        #endregion
    }
}
