using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UltimateInvocing.Models
{
    [Table("Companies")]
    public class Company : Entity<Guid>
    {
        public Company() {}
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

        [Required()]
        [MinLength(2)]
        [MaxLength(256)]
        public string Logo { get; set; }

        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string BTW { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        [ForeignKey(nameof(ProvinceId))]
        public Guid ProvinceId { get; set; }
        public Province Province { get; set; }

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
    }
}
