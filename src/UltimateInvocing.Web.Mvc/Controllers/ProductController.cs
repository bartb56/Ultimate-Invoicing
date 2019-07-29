using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimateInvocing.Authorization;
using UltimateInvocing.Controllers;
using UltimateInvocing.Factories.Product;
using UltimateInvocing.Product;
using UltimateInvocing.Web.Models.Product;

namespace UltimateInvocing.Web.Mvc.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Products)]
    public class ProductController : UltimateInvocingControllerBase
    {
        private readonly IProductFactory _factory;

        public ProductController(IProductFactory factory)
        {
            _factory = factory;
        }

        [Route("Products/")]
        public async Task<IActionResult> Index()
        {
            return View(await _factory.PrepareListModel());
        }

        public async Task<ActionResult> EditProductModal(Guid productId)
        {
            return View("_EditProductModal", await _factory.PrepareEditModel(productId));
        }
    }
}