using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UltimateInvocing.Controllers;
using UltimateInvocing.Customers.Address.AddressDto;
using UltimateInvocing.Factories.Order;

namespace UltimateInvocing.Web.Mvc.Controllers
{
    public class OrderController : UltimateInvocingControllerBase
    {
        private readonly IOrderFactory _factory;
        public OrderController(IOrderFactory factory)
        {
            _factory = factory;
        }
        [Route("Orders/")]
        public async Task<IActionResult> Index()
        {
            return View(await _factory.PrepareListModel());
        }

        [HttpPost]
        public async Task<List<AdressDTO>> UpdateAddresses(Guid customerId)
        {
            return await _factory.UpdateAddressByCustomerId(customerId);
        }

        [HttpPost]
        public async Task UpdateCustomerDetails(Guid orderId)
        {
            await _factory.UpdateCustomerDetails(orderId);
            return;
        }
        [HttpPost]
        public async Task UpdateCompanyDetails(Guid orderId)
        {
            await _factory.UpdateCompanyDetails(orderId);
            return;
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid orderId)
        {
            return View(await _factory.PrepareEditModel(orderId));
        }
    }
}