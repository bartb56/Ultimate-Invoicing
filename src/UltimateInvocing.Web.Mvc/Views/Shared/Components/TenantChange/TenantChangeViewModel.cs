using Abp.AutoMapper;
using UltimateInvocing.Sessions.Dto;

namespace UltimateInvocing.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
