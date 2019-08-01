using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Runtime.Validation;
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

        [Route("Orders/EditOrderModal/{orderId}/")]
        public async Task<ActionResult> EditOrderModal(Guid orderId)
        {
            return View("Edit", await _factory.PrepareEditModel(orderId));
        }

        [Route("Orders/")]
        public async Task<IActionResult> Index()
        {
            return View(await _factory.PrepareListModel());
        }

        [Route("Orders/UpdateAddresses/{customerId}/")]
        public async Task<List<AdressDTO>> UpdateAddresses(Guid customerId)
        {
            return await _factory.UpdateAddressByCustomerId(customerId);
        }

        [Route("Orders/UpdateCustomerDetails/{orderId}/")]
        public async Task UpdateCustomerDetails(Guid orderId)
        {
            await _factory.UpdateCustomerDetails(orderId);
            return;
        }
        [Route("Orders/UpdateCompanyDetails/{orderId}/")]
        public async Task UpdateCompanyDetails(Guid orderId)
        {
            await _factory.UpdateCompanyDetails(orderId);
            return;
        }

        //public async Task<ActionResult> Edit(Guid orderId)
        //{
        //    return View(await _factory.PrepareEditModel(orderId));
        //    return View();
        //}

    }
}