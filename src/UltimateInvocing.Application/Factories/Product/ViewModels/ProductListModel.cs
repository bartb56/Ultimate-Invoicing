using System;
using System.Collections.Generic;
using System.Text;
using UltimateInvocing.Product.Dto;

namespace UltimateInvocing.Factories.Product.ViewModels
{
    public class ProductListModel
    {
        public IReadOnlyList<ProductDto> Products { get; set; }
        public int NextProductNumber { get; set; }
    }
}
