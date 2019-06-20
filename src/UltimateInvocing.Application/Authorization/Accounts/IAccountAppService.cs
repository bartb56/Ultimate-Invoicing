using System.Threading.Tasks;
using Abp.Application.Services;
using UltimateInvocing.Authorization.Accounts.Dto;

namespace UltimateInvocing.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
