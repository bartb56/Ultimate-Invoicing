using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UltimateInvocing.Models
{
    public class Customer : Entity<Guid>
    {
        public Customer() { }

        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string CompanyName { get; set; }

        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string CompanyEmail { get; set; }

        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string CompanyPhonenumber { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
