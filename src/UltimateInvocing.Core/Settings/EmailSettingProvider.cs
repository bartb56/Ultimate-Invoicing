using Abp.Configuration;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using UltimateInvocing.Services.Email;

namespace UltimateInvocing.Settings
{
    public class EmailSettingProvider : SettingProvider
    {
        private readonly IEmailService _emailService;

        public EmailSettingProvider(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            var settings = _emailService.GetEmailSettings();

            return new[]
                    {
                new SettingDefinition(
                        "Abp.Net.Mail.DefaultFromAddress",
                        settings.DefaultFromAddress,
                        scopes: SettingScopes.Application,
                        clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()
                ),
                new SettingDefinition(
                    "Abp.Net.Mail.Smtp.Host",
                    settings.Host,
                    scopes: SettingScopes.Application,
                    clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()
                ),

                new SettingDefinition(
                    "Abp.Net.Mail.Smtp.Port",
                    settings.Port,
                    scopes: SettingScopes.Application,
                    clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()
                ),
                new SettingDefinition(
                    "Abp.Net.Mail.DefaultFromDisplayName",
                    settings.DefaultFromDisplayName,
                    scopes: SettingScopes.Application,
                    clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()
                ),
                new SettingDefinition(
                    "Abp.Net.Mail.Smtp.UserName",
                    settings.UserName,
                    scopes: SettingScopes.Application,
                    clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()
                ),
                new SettingDefinition(
                    "Abp.Net.Mail.Smtp.Password",
                    settings.Password,
                    scopes: SettingScopes.Application,
                    clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()
                ),
                new SettingDefinition(
                    "Abp.Net.Mail.Smtp.EnableSsl",
                    settings.EnableSsl.ToString(),
                    scopes: SettingScopes.Application,
                    clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()
                ),
                new SettingDefinition(
                    "Abp.Net.Mail.Smtp.UseDefaultCredentials",
                    settings.UseDefaultCredentials.ToString(),
                    scopes: SettingScopes.Application,
                    clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()
                )
                };
        }
    }
}