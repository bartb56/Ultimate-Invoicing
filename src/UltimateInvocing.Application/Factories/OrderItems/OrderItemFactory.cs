using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.OrderItem;

namespace UltimateInvocing.Factories.OrderItems
{
    public class OrderItemFactory : IOrderItemFactory
    {
        private readonly IOrderItemAppService _appService;

        public OrderItemFactory(IOrderItemAppService appService)
        {
            _appService = appService;
        }

        public async Task<OrderItemsListModel> PrepareListModel(Guid orderId)
        {
            var orderItems = await _appService.GetAllByOrderId(orderId);
            var model = new OrderItemsListModel { OrderItems = orderItems };
            return model;
        }
    }
}
