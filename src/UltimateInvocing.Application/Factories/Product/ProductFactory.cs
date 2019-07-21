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

        public Task PrepareEditModel()
        {
            throw new NotImplementedException();
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
