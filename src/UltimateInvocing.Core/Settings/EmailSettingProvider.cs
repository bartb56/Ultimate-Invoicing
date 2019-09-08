using Abp.Configuration;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateInvocing.Settings
{
    public class EmailSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
                    {
                new SettingDefinition(
                        "Abp.Net.Mail.DefaultFromAddress",
                        "donotreply@ultimateinvoicing.com",
                        scopes: SettingScopes.User,
                        clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()
                ),
                new SettingDefinition(
                    "Abp.Net.Mail.Smtp.Host",
                    "mail.ultimateinvoicing.com"
                ),

                new SettingDefinition(
                    "Abp.Net.Mail.Smtp.Port",
                    "8889",
                    scopes: SettingScopes.User,
                    clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()
                ),
                new SettingDefinition(
                    "Abp.Net.Mail.DefaultFromDisplayName",
                    "Ultimate invoicing",
                    scopes: SettingScopes.User,
                    clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()
                ),
                new SettingDefinition(
                    "Abp.Net.Mail.Smtp.UserName",
                    "donotreply@ultimateinvoicing.com",
                    scopes: SettingScopes.User,
                    clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()
                ),
                new SettingDefinition(
                    "Abp.Net.Mail.Smtp.Password",
                    "@5zZ6Eq$MgeN",
                    scopes: SettingScopes.User,
                    clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()
                ),
                new SettingDefinition(
                    "Abp.Net.Mail.Smtp.EnableSsl",
                    "false",
                    scopes: SettingScopes.User,
                    clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()
                ),
                new SettingDefinition(
                    "Abp.Net.Mail.Smtp.UseDefaultCredentials",
                    "false",
                    scopes: SettingScopes.User,
                    clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()
                )
                };
        }
    }
}