using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UltimateInvocing.Factories.OrderItems
{
    public interface IOrderItemFactory
    {
        Task<OrderItemsListModel> PrepareListModel(Guid orderId);
    }
}
