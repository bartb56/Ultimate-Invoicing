using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateInvocing.Authorization;
using UltimateInvocing.Controllers;
using UltimateInvocing.Country;
using UltimateInvocing.Web.Models.Country;

namespace UltimateInvocing.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_General_Settings)]
    public class CountryController : UltimateInvocingControllerBase
    {
        private readonly ICountryAppService _countryAppService;
        public CountryController(ICountryAppService countryAppService)
        {
            _countryAppService = countryAppService;
        }

        [Route("Countries/")]
        public async Task<IActionResult> Index()
        {
            var countries = await _countryAppService.GetAll();
            var model = new CountryListModel()
            {
                Countries = countries
            };
            return View(model);
        }


        public async Task<ActionResult> EditCountryModal(Guid countryId)
        {
            var output = await _countryAppService.GetById(countryId);
            var model = new EditCountryModalViewModel(output);

            return View("EditCountryModal", model);
        }
    }
}
