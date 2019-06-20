using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using UltimateInvocing.Configuration.Dto;

namespace UltimateInvocing.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : UltimateInvocingAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
