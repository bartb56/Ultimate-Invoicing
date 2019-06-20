using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateInvocing.Country.Dto
{
    public class PagedCountryResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
