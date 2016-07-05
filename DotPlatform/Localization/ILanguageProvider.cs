using System.Collections.Generic;

namespace DotPlatform.Localization
{
    /// <summary>
    /// 语言提供者
    /// </summary>
    public interface ILanguageProvider
    {
        /// <summary>
        /// 获取所有语言
        /// </summary>
        IReadOnlyList<LanguageInfo> GetLanguages();
    }
}
