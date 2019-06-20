using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UltimateInvocing.Models
{
    public class CustomerAddress : Entity<Guid>
    {
        [ForeignKey(nameof(CustomerId))]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey(nameof(AddressId))]
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}
