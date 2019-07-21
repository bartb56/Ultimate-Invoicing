using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using UltimateInvocing.Order.Dto;

namespace UltimateInvocing.Factories.Order
{
    public class OrderListModel
    {
        public IReadOnlyList<OrderDto> orders { get; set; }

        public List<SelectListItem> Companies { get; set; }
        public List<SelectListItem> PaymentTypes { get; set; }
        public List<SelectListItem> Customers { get; set; }
        public List<SelectListItem> Addresses { get; set; }
    }
}
