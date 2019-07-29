using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Factories.Product.ViewModels;
using UltimateInvocing.Product;

namespace UltimateInvocing.Factories.Product
{
    public class ProductFactory : IProductFactory
    {
        private readonly IProductAppService _appService;
        public ProductFactory(IProductAppService appService)
        {
            _appService = appService;
        }

        public async Task<EditProductViewModel> PrepareEditModel(Guid productId)
        {
            var product = await _appService.GetById(productId);

            var model = new EditProductViewModel
            {
                Price = product.Price,
                Description = product.Description,
                IsAvailable = product.IsAvailable,
                Name = product.Name,
                Number = product.Number,
                SKUCode = product.SKUCode,
                Id = product.Id,
                Tax = product.Tax,
                Weight = product.Weight
            };
            return model;
        }

        public async Task<ProductListModel> PrepareListModel()
        {
            var products = await _appService.GetAll();
            var number = await _appService.HighestProductNumber();
            number++;
            var model = new ProductListModel()
            {
                NextProductNumber = number,
                Products = products
            };
            return model;
        }
    }
}
