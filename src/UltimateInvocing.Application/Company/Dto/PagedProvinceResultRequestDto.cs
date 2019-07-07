using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateInvocing.Company.Dto
{
    [AutoMap(typeof(UltimateInvocing.Models.Company))]
    public class PagedCompanyResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
