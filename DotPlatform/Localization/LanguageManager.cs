using System;
using System.Linq;
using System.Threading;

namespace DotPlatform.Localization
{
    /// <summary>
    /// 语言管理者
    /// </summary>
    public class LanguageManager : ILanguageManager
    {
        private readonly ILanguageProvider _languageProvider;

        public LanguageManager(ILanguageProvider languageProvider)
        {
            _languageProvider = languageProvider;
        }

        public LanguageInfo CurrentLanguage
        {
            get
            {
                return this.GetCurrentLanguage();
            }
        }

        private LanguageInfo GetCurrentLanguage()
        {
            var languages = _languageProvider.GetLanguages();
            if (!languages.Any())
            {
                throw new DotPlatformException("No language defined in this application.");
            }

            var currentCultureName = Thread.CurrentThread.CurrentUICulture.Name;

            //Try to find exact match
            var currentLanguage = languages.FirstOrDefault(l => l.Name == currentCultureName);
            if (currentLanguage != null)
            {
                return currentLanguage;
            }

            //Try to find best match
            currentLanguage = languages.FirstOrDefault(l => currentCultureName.StartsWith(l.Name));
            if (currentLanguage != null)
            {
                return currentLanguage;
            }

            //Try to find default language
            currentLanguage = languages.FirstOrDefault(l => l.IsDefault);
            if (currentLanguage != null)
            {
                return currentLanguage;
            }

            //Get first one
            return languages[0];
        }
    }
}
