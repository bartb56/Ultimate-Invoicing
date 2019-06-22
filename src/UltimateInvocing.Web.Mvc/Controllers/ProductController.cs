using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimateInvocing.Authorization;
using UltimateInvocing.Controllers;
using UltimateInvocing.Product;
using UltimateInvocing.Web.Models.Product;

namespace UltimateInvocing.Web.Mvc.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Products)]
    public class ProductController : UltimateInvocingControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [Route("Products/")]
        public async Task<IActionResult> Index()
        {
            var model = new ProductListModel()
            {
                Products =  await _productAppService.GetAll()
            };
            return View(model);
        }
    }
}