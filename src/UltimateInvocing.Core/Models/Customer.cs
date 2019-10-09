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
        public int Number { get; set; }

        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string CustomerName { get; set; }

        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string CustomerEmail { get; set; }

        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string CustomerMainPhonenumber { get; set; }

        [MaxLength(128)]
        public string CustomerTaxNumber { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
