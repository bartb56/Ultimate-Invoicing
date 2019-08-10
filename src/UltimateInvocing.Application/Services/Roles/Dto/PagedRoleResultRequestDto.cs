using Abp.Application.Services.Dto;

namespace UltimateInvocing.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

