using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UltimateInvocing.Controllers;
using UltimateInvocing.Country;
using UltimateInvocing.Customers.Address;
using UltimateInvocing.Province;
using UltimateInvocing.Province.Dto;
using UltimateInvocing.Web.Models.Address;

namespace UltimateInvocing.Web.Mvc.Controllers
{
    public class AddressController : UltimateInvocingControllerBase
    {
        private readonly IAddressAppService _addressAppService;
        private readonly ICountryAppService _countryAppService;
        private readonly IProvinceAppService _provinceAppService;

        public AddressController(IAddressAppService addressAppService,
            ICountryAppService countryAppService,
            IProvinceAppService provinceAppService)
        {
            _addressAppService = addressAppService;
            _countryAppService = countryAppService;
            _provinceAppService = provinceAppService;
        }

        [Route("Customer/address/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(Guid id)
        {
            var addresses = await _addressAppService.GetAllByUserId(id);

            var provinces = await _provinceAppService.GetAll();
            var countries = await _countryAppService.GetAll();

            if(!countries.Any())
            {
                throw new Exception("No countries found!");
            }

            IEnumerable<SelectListItem> selectListCountries = countries.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            IEnumerable<SelectListItem> selectListProvinces = provinces.Where(x => x.CountryId == countries.First().Id).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            var addressViewModel = new AddressListModel()
            {
                CustomerId = id,
                Addresses = addresses,
                Countries = selectListCountries,
                Provinces = selectListProvinces
            };
            return View(addressViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditAddressModal(Guid addressId)
        {
            var output = await _addressAppService.GetById(addressId);

            var provinces = await _provinceAppService.GetAll();
            var countries = await _countryAppService.GetAll();

            if (!countries.Any())
            {
                throw new Exception("No countries found!");
            }

            IEnumerable<SelectListItem> selectListCountries = countries.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            IEnumerable<SelectListItem> selectListProvinces = provinces.Where(x => x.CountryId == output.CountryId).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            var model = new EditAddressViewModel(output);

            selectListCountries.FirstOrDefault(x => x.Value == output.CountryId.ToString()).Selected = true;
            selectListProvinces.FirstOrDefault(x => x.Value == output.ProvinceId.ToString()).Selected = true;

            model.Provinces = selectListProvinces;
            model.Countries = selectListCountries;

            return View("_EditAddressModal", model);
        }

        [HttpPost]
        public async Task<List<ProvinceDto>> UpdateProvinceList(Guid countryId)
        {
            return await _provinceAppService.GetAllByCountryId(countryId);
        }
    }
}