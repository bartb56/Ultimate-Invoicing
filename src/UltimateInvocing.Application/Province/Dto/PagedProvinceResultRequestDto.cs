using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateInvocing.Province.Dto
{
    [AutoMap(typeof(UltimateInvocing.Models.Province))]
    public class PagedProvinceResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
