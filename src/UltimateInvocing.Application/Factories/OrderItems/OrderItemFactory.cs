using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.OrderItem;
using UltimateInvocing.OrderItem.Dto;
using UltimateInvocing.Product;

namespace UltimateInvocing.Factories.OrderItems
{
    public class OrderItemFactory : IOrderItemFactory
    {
        private readonly IOrderItemAppService _appService;
        private readonly IProductAppService _productAppService;

        public OrderItemFactory(IOrderItemAppService appService,
            IProductAppService productAppService)
        {
            _appService = appService;
            _productAppService = productAppService;
        }

        public async Task<OrderItemsListModel> PrepareListModel(Guid orderId)
        {
            var products = await _productAppService.GetAll();
            var orderItems = await _appService.GetAllByOrderId(orderId);
            var model = new OrderItemsListModel { OrderItems = orderItems, OrderId = orderId };
            model.Products = products.Select(x => new SelectListItem { Text = x.Number + " " + x.Name, Value = x.Id.ToString() }).ToList();

            float total = 0;
            float tax = 0;
            float totalTax = 0;

            foreach(OrderItemDto orderItem in orderItems)
            {
                total += orderItem.Price * orderItem.Quantity;
                tax += (orderItem.Price / 100 * orderItem.Tax) * orderItem.Quantity;
            }

            totalTax = total + tax;

            model.Total = total;
            model.Tax = tax;
            model.TotalTax = totalTax;
            return model;
        }
    }
}
