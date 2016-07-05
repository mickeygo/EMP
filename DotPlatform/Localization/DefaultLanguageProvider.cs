using System;
using System.Collections.Generic;

namespace DotPlatform.Localization
{
    /// <summary>
    /// 语言提供者
    /// </summary>
    public class DefaultLanguageProvider : ILanguageProvider
    {
        public IReadOnlyList<LanguageInfo> GetLanguages()
        {
            throw new NotImplementedException();
        }
    }
}
