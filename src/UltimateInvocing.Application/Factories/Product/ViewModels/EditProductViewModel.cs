using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UltimateInvocing.Models;

namespace UltimateInvocing.Factories.Product.ViewModels
{
    public class EditProductViewModel
    {
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
        [Required()]
        public int Stock { get; set; }

        public Guid TaxGroupId { get; set; }
        public IEnumerable<SelectListItem> TaxGroups { get; set; }
    }
}
