using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Json;
using Abp.Reflection.Extensions;

namespace Mall.Localization
{
    public static class MallLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Languages.Add(new LanguageInfo("zh-ch", "中文", "famfamfam-flags cn", isDefault: true));
            localizationConfiguration.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flags england"));

            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MallConsts.LocalizationSourceName,
                    new JsonEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MallLocalizationConfigurer).GetAssembly(),
                        "Mall.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}