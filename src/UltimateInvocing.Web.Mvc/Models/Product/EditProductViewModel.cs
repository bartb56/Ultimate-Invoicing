using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UltimateInvocing.Product.Dto;

namespace UltimateInvocing.Web.Models.Product
{
    public class EditProductViewModel
    {
        public EditProductViewModel(ProductDto output)
        {
            Id = output.Id;
            Number = output.Number;
            Name = output.Name;
            Description = output.Description;
            SKUCode = output.SKUCode;
            Weight = output.Weight;
            Price = output.Price;
            Tax = output.Tax;
            IsAvailable = output.IsAvailable;
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
        [Required()]
        [MaxLength(128)]
        [MinLength(2)]
        public string Name { get; set; }
        [MaxLength(128)]
        public string Description { get; set; }
        [MaxLength(128)]
        public string SKUCode { get; set; }

        public float Weight { get; set; }
        public float Price { get; set; }
        public int Tax { get; set; }
        [Required()]
        public bool IsAvailable { get; set; }
    }
}
