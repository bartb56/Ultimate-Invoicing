using Abp.Application.Services;
using Abp.Application.Services.Dto;
using UltimateInvocing.MultiTenancy.Dto;

namespace UltimateInvocing.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

