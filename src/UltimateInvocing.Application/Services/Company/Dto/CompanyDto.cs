using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UltimateInvocing.Company.Dto
{
    [AutoMap(typeof(UltimateInvocing.Models.Company))]
    public class CompanyDto : EntityDto<Guid>
    {
        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string KVK { get; set; }

        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string IBAN { get; set; }

        public string Logo { get; set; }

        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string BTW { get; set; }

        [Required()]
        public virtual Guid CountryId { get; set; }
        public virtual Models.Country Country { get; set; }

        [Required()]
        public virtual Guid ProvinceId { get; set; }
        public virtual Models.Province Province { get; set; }

        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string City { get; set; }

        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string StreetAddress { get; set; }

        [Required()]
        [MinLength(1)]
        [MaxLength(128)]
        public string HouseNumber { get; set; }

        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string PostalCode { get; set; }

        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string PhoneNumber { get; set; }

        public IFormFile File { get; set; }
    }
}
