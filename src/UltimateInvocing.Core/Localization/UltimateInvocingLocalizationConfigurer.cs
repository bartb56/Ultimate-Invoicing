using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace UltimateInvocing.Localization
{
    public static class UltimateInvocingLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(UltimateInvocingConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(UltimateInvocingLocalizationConfigurer).GetAssembly(),
                        "UltimateInvocing.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
