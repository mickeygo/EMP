using System;

namespace DotPlatform.Web.Models
{
    /// <summary>
    /// 用于存储验证出错的信息
    /// </summary>
    [Serializable]
    public class ValidationErrorInfo
    {
        /// <summary>
        /// 获取或设置验证错误的信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 获取或设置错误信息关联的无效成员（字段/属性）
        /// </summary>
        public string[] Members { get; set; }

        #region Ctor

        /// <summary>
        /// 初始化一个新的<see cref="ValidationErrorInfo"/>对象
        /// </summary>
        public ValidationErrorInfo()
        {

        }

        /// <summary>
        /// 初始化一个新的<see cref="ValidationErrorInfo"/>对象
        /// </summary>
        /// <param name="message">验证错误的信息</param>
        public ValidationErrorInfo(string message)
        {
            Message = message;
        }

        /// <summary>
        /// 初始化一个新的<see cref="ValidationErrorInfo"/>对象
        /// </summary>
        /// <param name="message">验证错误的信息</param>
        /// <param name="members">关联的无效成员</param>
        public ValidationErrorInfo(string message, string[] members)
            : this(message)
        {
            Members = members;
        }

        /// <summary>
        /// 初始化一个新的<see cref="ValidationErrorInfo"/>对象
        /// </summary>
        /// <param name="message">验证错误的信息</param>
        /// <param name="member">关联的无效成员</param>
        public ValidationErrorInfo(string message, string member)
            : this(message, new[] { member })
        {

        }

        #endregion
    }
}
