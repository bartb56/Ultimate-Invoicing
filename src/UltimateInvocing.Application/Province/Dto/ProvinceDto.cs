using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UltimateInvocing.Province.Dto
{
    [AutoMap(typeof(UltimateInvocing.Models.Province))]
    public class ProvinceDto : EntityDto<Guid>
    {
        [Required()]
        [MaxLength(128)]
        [MinLength(2)]
        public string Name { get; set; }

        public Guid CountryId { get; set; }
        public virtual Models.Country Country { get; set; }
    }
}
