using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UltimateInvocing.Models
{
    [Table("Provinces")]
    public class Province : Entity<Guid>
    {
        public Province() { }

        [Required()]
        [MaxLength(128)]
        [MinLength(2)]
        public string Name { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Guid CountryId { get; set; }
        public Country Country { get; set; }

    }
}
