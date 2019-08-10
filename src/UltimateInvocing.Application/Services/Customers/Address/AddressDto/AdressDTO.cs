using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UltimateInvocing.Customers.Address.AddressDto
{
    [AutoMap(typeof(UltimateInvocing.Models.Address))]
    public class AdressDTO : EntityDto<Guid>
    {
        public virtual Guid CountryId { get; set; }
        public virtual Models.Country Country { get; set; }

        public virtual Guid ProvinceId { get; set; }
        public virtual Models.Province Province { get; set; }

        public Guid CustomerId { get; set; }

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

        public bool Taxable { get; set; }
    }
}
