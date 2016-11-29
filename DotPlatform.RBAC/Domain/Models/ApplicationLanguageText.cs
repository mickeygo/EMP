using System;
using DotPlatform.Domain.Entities;

namespace DotPlatform.RBAC.Domain.Models
{
    /// <summary>
    /// 应用程序语言文本
    /// </summary>
    public class ApplicationLanguageText
    {
        /// <summary>
        /// 语言名,必须为 culture code
        /// https://msdn.microsoft.com/en-us/library/ee825488(v=cs.20).aspx
        /// </summary>
        public string LanguageName { get; set; }

        /// <summary>
        /// 文本 Key 值
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 文本 Value 值
        /// </summary>
        public string Value { get; set; }
    }
}
