using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using UltimateInvocing.Configuration;

namespace UltimateInvocing.Web.Startup
{
    [DependsOn(typeof(UltimateInvocingWebCoreModule))]
    public class UltimateInvocingWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public UltimateInvocingWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<UltimateInvocingNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(UltimateInvocingWebMvcModule).GetAssembly());
        }
    }
}
