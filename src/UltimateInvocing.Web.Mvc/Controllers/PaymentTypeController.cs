using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UltimateInvocing.Controllers;
using UltimateInvocing.Factories.PaymentType;

namespace UltimateInvocing.Web.Mvc.Controllers
{
    public class PaymentTypeController : UltimateInvocingControllerBase
    {
        private readonly IPaymentTypeFactory _factory;
        public PaymentTypeController(IPaymentTypeFactory factory)
        {
            _factory = factory;
        }

        [Route("Settings/PaymentTypes")]
        public async Task<IActionResult> Index()
        {
            return View(await _factory.PrepareListModel());
        }

        public async Task<IActionResult> EditPaymentTypeModal(Guid paymentTypeId)
        {
            var output = await _factory.PrepareEditModel(paymentTypeId);

            return View("_EditPaymentTypeModal", output);
        }
    }
}