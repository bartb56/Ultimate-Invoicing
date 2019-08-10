using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateInvocing.Product.Dto
{
    public class PagedProductResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
