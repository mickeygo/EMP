namespace DotPlatform.RBAC.Domain.Models
{
    /// <summary>
    /// 应用程序语言
    /// </summary>
    public class ApplicationLanguage
    {
        /// <summary>
        /// 语言名,必须为 culture code
        /// https://msdn.microsoft.com/en-us/library/ee825488(v=cs.20).aspx
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 语言显示名
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 语言图标
        /// </summary>
        public string Icon { get; set; }
    }
}
