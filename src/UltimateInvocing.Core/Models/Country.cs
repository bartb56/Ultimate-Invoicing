using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UltimateInvocing.Models
{
    public class Country : Entity<Guid>
    {
        [Required()]
        [MaxLength(128)]
        [MinLength(2)]
        public string Name { get; set; }
        [MaxLength(2)]
        public string IsoCode { get; set; }
        [MaxLength(3)]
        public string IsoCode3 { get; set; }

        public virtual ICollection<Province> Provinces { get; set; }

        //Ef core ctor
        public Country() { }
    }
}
