using Abp.Dependency;
using Abp.MailKit;
using Abp.Modules;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using UltimateInvocing.Authorization.Roles;
using UltimateInvocing.Authorization.Users;
using UltimateInvocing.Configuration;
using UltimateInvocing.Localization;
using UltimateInvocing.MultiTenancy;
using UltimateInvocing.Timing;

namespace UltimateInvocing
{
    [DependsOn(typeof(AbpZeroCoreModule),
        typeof(AbpMailKitModule))]
    public class UltimateInvocingCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            UltimateInvocingLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = UltimateInvocingConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            IocManager.Register<ISmtpEmailSenderConfiguration, SmtpEmailSenderConfiguration>();
            IocManager.Register<ISmtpEmailSender, SmtpEmailSender>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(UltimateInvocingCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
