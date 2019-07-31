using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimateInvocing.Authorization;
using UltimateInvocing.Controllers;
using UltimateInvocing.Customers;
using UltimateInvocing.Customers.Address.AddressDto;
using UltimateInvocing.Web.Models.Country;
using UltimateInvocing.Web.Models.Customer;

namespace UltimateInvocing.Web.Mvc.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Customers)]
    public class CustomerController : UltimateInvocingControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [Route("Customers/")]
        public async Task<IActionResult> Index()
        {
            var customers = await _customerAppService.GetAll();
            var numbers = customers.Select(x => x.Number);
            int number = 1;
            if(numbers.Any())
                number = numbers.Max() + 1;
            var model = new CustomerListModel()
            {
                Customers = customers,
                NextCustomerNumber = number
            };
            return View(model);
        }

        public async Task<ActionResult> EditCustomerModal(Guid customerId)
        {
            var output = await _customerAppService.GetById(customerId);
            var model = new EditCustomerViewModel(output);

            return View("_EditCustomerModal", model);
        }
    }
}