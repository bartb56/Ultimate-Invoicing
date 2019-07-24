using System;
using System.Collections.Generic;
using System.Text;
using UltimateInvocing.OrderItem.Dto;

namespace UltimateInvocing.Factories.OrderItems
{
    public class OrderItemsListModel
    {
        public IList<OrderItemDto> OrderItems { get; set; }
    }
}
