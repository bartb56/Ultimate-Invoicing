using Abp.AutoMapper;
using Abp.MailKit;
using Abp.Modules;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Reflection.Extensions;
using UltimateInvocing.Authorization;
using UltimateInvocing.Configuration;
using UltimateInvocing.Settings;

namespace UltimateInvocing
{
    [DependsOn(
        typeof(UltimateInvocingCoreModule), 
        typeof(AbpAutoMapperModule),
        typeof(AbpMailKitModule))]
    public class UltimateInvocingApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<UltimateInvocingAuthorizationProvider>();
            Configuration.Settings.Providers.Add<EmailSettingProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(UltimateInvocingApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
