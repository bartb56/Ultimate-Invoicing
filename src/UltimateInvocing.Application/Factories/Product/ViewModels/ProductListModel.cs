using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using UltimateInvocing.Models;
using UltimateInvocing.Product.Dto;

namespace UltimateInvocing.Factories.Product.ViewModels
{
    public class ProductListModel
    {
        public IReadOnlyList<ProductDto> Products { get; set; }
        public int NextProductNumber { get; set; }
        public IEnumerable<SelectListItem> TaxGroups { get; set; }
    }
}
