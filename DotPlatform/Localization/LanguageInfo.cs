namespace DotPlatform.Localization
{
    /// <summary>
    /// 语言信息
    /// </summary>
    public class LanguageInfo
    {
        /// <summary>
        /// 基于文化语言代码
        /// Ex: "en-US" for American English, "tr-TR" for Turkey Turkish.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 语言代码对应的语言显示名称
        /// Ex: "English" for English, "ZH-CN" for Chinese.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 显示在 UI 上的语言 icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 是否作为默认语言
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
