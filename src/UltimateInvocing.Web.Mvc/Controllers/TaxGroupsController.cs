using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UltimateInvocing.Authorization;
using UltimateInvocing.Controllers;
using UltimateInvocing.Services.TaxGroups;
using UltimateInvocing.Web.Models.TaxGroup;

namespace UltimateInvocing.Web.Mvc.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_TaxGroups)]
    public class TaxGroupsController : UltimateInvocingControllerBase
    {
        private readonly ITaxGroupAppService _taxGroupAppService;

        public TaxGroupsController(ITaxGroupAppService taxGroupAppService)
        {
            _taxGroupAppService = taxGroupAppService;
        }

        [Route("Settings/TaxGroups")]
        public async Task<IActionResult> Index()
        {
            var model = new TaxGroupListViewModel()
            {
                TaxGroups = await _taxGroupAppService.GetAll()
            };
            return View(model);
        }
    }
}