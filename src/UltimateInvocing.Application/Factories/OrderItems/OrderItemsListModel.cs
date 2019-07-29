using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using UltimateInvocing.OrderItem.Dto;

namespace UltimateInvocing.Factories.OrderItems
{
    public class OrderItemsListModel
    {
        public IList<OrderItemDto> OrderItems { get; set; }

        public Guid OrderId { get; set; }
        public List<SelectListItem> Products { get; set; }

        public float Total { get; set; }
        public float Tax { get; set; }
        public float TotalTax { get; set; }

    }
}
