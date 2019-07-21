using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UltimateInvocing.Company;
using UltimateInvocing.Company.Dto;
using UltimateInvocing.Controllers;
using UltimateInvocing.Country;
using UltimateInvocing.Province;
using UltimateInvocing.Web.Factories.Company;

namespace UltimateInvocing.Web.Mvc.Controllers
{
    public class CompanyController : UltimateInvocingControllerBase
    {
        private readonly ICompanyFactory _factory;

        public CompanyController(ICompanyFactory factory)
        {
            _factory = factory;
        }

        [Route("Companies/")]
        public async Task<IActionResult> Index()
        {
            return View(await _factory.PrepareCompanyModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyDto companyDto)
        {
            await _factory.Create(companyDto);
            return RedirectToAction("index", await _factory.PrepareCompanyModel());
        } 

        [HttpPost]
        public async Task<IActionResult> EditCompanyModel(Guid id)
        {
            var model = await _factory.PrepareEditModal(id);
            return View("EditCompanyModal", model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyDto companyDto)
        {
            await _factory.Edit(companyDto);
            return RedirectToAction("index", await _factory.PrepareCompanyModel());
        }
    }
}