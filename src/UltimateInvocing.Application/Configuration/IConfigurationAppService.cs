using System.Threading.Tasks;
using UltimateInvocing.Configuration.Dto;

namespace UltimateInvocing.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
