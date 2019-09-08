using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Configuration;
using Abp.Localization;
using Abp.Net.Mail;
using UltimateInvocing.Configuration;

namespace UltimateInvocing.EntityFrameworkCore.Seed.Host
{
    public class DefaultSettingsCreator
    {
        private readonly UltimateInvocingDbContext _context;

        public DefaultSettingsCreator(UltimateInvocingDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            // Emailing
            AddSettingIfNotExists(EmailSettingNames.DefaultFromAddress, "mail.ultimateinvoicing.com");
            AddSettingIfNotExists(EmailSettingNames.DefaultFromDisplayName, "Ultimate invoicing");
            AddSettingIfNotExists(EmailSettingNames.Smtp.UserName, "mail.ultimateinvoicing.com");
            AddSettingIfNotExists(EmailSettingNames.Smtp.Domain, "ultimateinvoicing.com");
            AddSettingIfNotExists(EmailSettingNames.Smtp.EnableSsl, "false");
            AddSettingIfNotExists(EmailSettingNames.Smtp.Host, "mail.ultimateinvoicing.com");
            AddSettingIfNotExists(EmailSettingNames.Smtp.Port, "8889");
            AddSettingIfNotExists(EmailSettingNames.Smtp.Password, "@5zZ6Eq$MgeN");
            AddSettingIfNotExists(EmailSettingNames.Smtp.UseDefaultCredentials, "false");

            // Languages
            AddSettingIfNotExists(LocalizationSettingNames.DefaultLanguage, "nl");
            AddSettingIfNotExists(AppSettingNames.UiTheme, "teal");
            
        }

        private void AddSettingIfNotExists(string name, string value, int? tenantId = null)
        {
            if (_context.Settings.IgnoreQueryFilters().Any(s => s.Name == name && s.TenantId == tenantId && s.UserId == null))
            {
                return;
            }

            _context.Settings.Add(new Setting(tenantId, null, name, value));
            _context.SaveChanges();
        }
    }
}
