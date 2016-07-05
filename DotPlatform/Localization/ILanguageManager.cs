namespace DotPlatform.Localization
{
    /// <summary>
    /// 语言管理者
    /// </summary>
    public interface ILanguageManager
    {
        /// <summary>
        /// 获取当前语言信息
        /// </summary>
        LanguageInfo CurrentLanguage { get; }
    }
}
