using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UltimateInvocing.Models
{
    [Table("OrderItems")]
    public class OrderItem : Entity<Guid>
    {
        public int Quantity { get; set; }
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

        public Guid ProductId { get; set; }

        public Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}
