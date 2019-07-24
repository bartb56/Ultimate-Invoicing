using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UltimateInvocing.Controllers;
using UltimateInvocing.Factories.OrderItems;

namespace UltimateInvocing.Web.Mvc.Controllers
{
    public class OrderItemController : UltimateInvocingControllerBase
    {
        private readonly IOrderItemFactory _factory;
        public OrderItemController(IOrderItemFactory factory)
        {
            _factory = factory;
        }

        [Route("Order/{orderId}")]
        public async Task<IActionResult> Index(Guid orderId)
        {
            return View(await _factory.PrepareListModel(orderId));
        }
    }
}