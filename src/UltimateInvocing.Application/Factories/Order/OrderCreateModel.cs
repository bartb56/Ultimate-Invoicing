using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UltimateInvocing.Factories.Order
{
    public class OrderCreateModel
    {
        public Guid OrderId { get; set; }

        [Required()]
        public int Number { get; set; }
        [Required()]
        public Guid CustomerId { get; set; }
        [Required()]
        public Guid CompanyId { get; set; }
        [Required()]
        public Guid PaymentMethodId { get; set; }
        [Required()]
        public Guid AddressId { get; set; }
    }
}
