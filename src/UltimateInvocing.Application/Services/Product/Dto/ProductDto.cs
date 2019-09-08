using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UltimateInvocing.Models;

namespace UltimateInvocing.Product.Dto
{
    [AutoMap(typeof(UltimateInvocing.Models.Product))]
    public class ProductDto : EntityDto<Guid>
    {
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

        [Required()]
        public bool IsAvailable { get; set; }

        [Required()]
        public int Stock { get; set; }
        [Required()]
        public Guid TaxGroupId { get; set; }
        public virtual TaxGroup TaxGroup { get; set; }
    }
}
