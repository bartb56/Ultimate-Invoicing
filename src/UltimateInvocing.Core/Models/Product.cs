using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UltimateInvocing.Models
{
    public class Product : Entity<Guid>
    {
        [MaxLength(15)]
        public int Number { get; set; }
        [Required()]
        [MaxLength(128)]
        [MinLength(2)]
        public string Name { get; set; }
        [MaxLength(128)]
        public string Description { get; set; }
        [MaxLength(128)]
        public string SKUCode { get; set; }
        [MaxLength(15)]
        public float Weight { get; set; }
        [MaxLength(15)]
        public float Price { get; set; }
        [MaxLength(15)]
        public int Tax { get; set; }
        [Required()]
        public bool IsAvailable { get; set; }
        [Required()]
        public int Stock { get; set; }
    }
}

