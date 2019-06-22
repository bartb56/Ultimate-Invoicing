using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UltimateInvocing.Country.Dto
{
    [AutoMap(typeof(UltimateInvocing.Models.Product))]
    public class CountryDto : EntityDto<Guid>
    {
        [Required()]
        [MaxLength(128)]
        [MinLength(2)]
        public string Name { get; set; }
        [MaxLength(2)]
        public string IsoCode { get; set; }
        [MaxLength(3)]
        public string IsoCode3 { get; set; }
    }
}
