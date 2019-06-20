using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UltimateInvocing.Authorization;
using UltimateInvocing.Controllers;
using UltimateInvocing.Country;
using UltimateInvocing.Province;
using UltimateInvocing.Web.Models.Province;

namespace UltimateInvocing.Web.Mvc.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_General_Settings)]
    public class ProvinceController : UltimateInvocingControllerBase
    {
        private readonly IProvinceAppService _provinceAppService;
        private readonly ICountryAppService _countryAppService;

        public ProvinceController(IProvinceAppService provinceAppService,
            ICountryAppService countryAppService)
        {
            _provinceAppService = provinceAppService;
            _countryAppService = countryAppService;
        }
        [Route("Provinces/")]
        public async Task<IActionResult> Index()
        {
            var provinces = await _provinceAppService.GetAll();
            var countries = await _countryAppService.GetAll();

            IEnumerable<SelectListItem> selectList = countries.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            var model = new ProvinceListModel()
            {
                Provinces = provinces,
                Countries = selectList
            };
            return View(model);
        }


        public async Task<ActionResult> EditProvinceModal(Guid provinceId)
        {
            var output = await _provinceAppService.GetById(provinceId);
            var model = new EditProvinceViewModel(output);

            var countries = await _countryAppService.GetAll();
            model.Countries = countries.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            model.Countries.FirstOrDefault(x => x.Value == model.CountryId.ToString()).Selected = true;

            return View("EditProvinceModal", model);
        }
    }
}