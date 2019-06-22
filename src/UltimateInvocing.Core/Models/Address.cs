using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UltimateInvocing.Models
{
    [Table("Addresses")]
    public class Address : Entity<Guid>
    {
        public Address() { }

        [ForeignKey(nameof(ProductId))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

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
        [MinLength(2)]
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
