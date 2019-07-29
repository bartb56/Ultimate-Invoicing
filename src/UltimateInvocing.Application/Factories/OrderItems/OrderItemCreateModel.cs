using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateInvocing.Factories.OrderItems
{
    public class OrderItemCreateModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
    }
}
