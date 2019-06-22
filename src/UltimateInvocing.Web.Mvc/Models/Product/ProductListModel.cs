using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateInvocing.Product.Dto;

namespace UltimateInvocing.Web.Models.Product
{
    public class ProductListModel
    {
        public ICollection<ProductDto> Products { get; set; }
    }
}
