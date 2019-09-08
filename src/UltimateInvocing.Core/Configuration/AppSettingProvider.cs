using System.Collections.Generic;
using Abp;
using Abp.Configuration;
using Abp.Localization;
using Abp.Net.Mail;

namespace UltimateInvocing.Configuration
{
    public class AppSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(AppSettingNames.UiTheme, "teal", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),
                new SettingDefinition(EmailSettingNames.Smtp.Host, "smtp.patatat.com", L("SmtpHost"), scopes: SettingScopes.Application | SettingScopes.Tenant)
            };
        }

        private static LocalizableString L(string name)
        {
            return new LocalizableString(name, AbpConsts.LocalizationSourceName);
        }
    } 
}
