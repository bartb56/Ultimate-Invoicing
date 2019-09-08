using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Factories.Product.ViewModels;
using UltimateInvocing.Product;
using UltimateInvocing.Services.TaxGroups;

namespace UltimateInvocing.Factories.Product
{
    public class ProductFactory : IProductFactory
    {
        private readonly IProductAppService _appService;
        private readonly ITaxGroupAppService _taxGroupAppService;
        public ProductFactory(IProductAppService appService,
            ITaxGroupAppService taxGroupAppService)
        {
            _appService = appService;
            _taxGroupAppService = taxGroupAppService;
        }

        public async Task<EditProductViewModel> PrepareEditModel(Guid productId)
        {
            var product = await _appService.GetById(productId);
            var taxGroups = await _taxGroupAppService.GetAll();
            var model = new EditProductViewModel
            {
                Price = product.Price,
                Description = product.Description,
                IsAvailable = product.IsAvailable,
                Name = product.Name,
                Number = product.Number,
                SKUCode = product.SKUCode,
                Id = product.Id,
                TaxGroupId = product.TaxGroupId,
                Weight = product.Weight,
                Stock = product.Stock,
                TaxGroups = taxGroups.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList()
            };
            if(model.TaxGroups != null && model.TaxGroups.Any())
            {
                var previousSelectedItem = model.TaxGroups.FirstOrDefault(x => x.Value == product.TaxGroupId.ToString());
                if(previousSelectedItem != null)
                {
                    model.TaxGroups.FirstOrDefault(x => x.Value == product.TaxGroupId.ToString()).Selected = true;
                }
            }
            return model;
        }

        public async Task<ProductListModel> PrepareListModel()
        {
            var products = await _appService.GetAll();
            var number = await _appService.HighestProductNumber();
            var taxGroups = await _taxGroupAppService.GetAll();


            number++;
            var model = new ProductListModel()
            {
                NextProductNumber = number,
                Products = products,
                TaxGroups = taxGroups.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name}).ToList()
            };
            return model;
        }
    }
}
