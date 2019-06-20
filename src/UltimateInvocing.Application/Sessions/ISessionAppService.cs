using System.Threading.Tasks;
using Abp.Application.Services;
using UltimateInvocing.Sessions.Dto;

namespace UltimateInvocing.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
