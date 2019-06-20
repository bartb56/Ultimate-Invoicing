using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using UltimateInvocing.Configuration;

namespace UltimateInvocing.Web.Host.Startup
{
    [DependsOn(
       typeof(UltimateInvocingWebCoreModule))]
    public class UltimateInvocingWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public UltimateInvocingWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(UltimateInvocingWebHostModule).GetAssembly());
        }
    }
}
