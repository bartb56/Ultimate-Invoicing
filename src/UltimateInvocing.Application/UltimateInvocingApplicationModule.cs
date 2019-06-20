using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using UltimateInvocing.Authorization;

namespace UltimateInvocing
{
    [DependsOn(
        typeof(UltimateInvocingCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class UltimateInvocingApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<UltimateInvocingAuthorizationProvider>();
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
