using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UltimateInvocing.Order.Dto;

namespace UltimateInvocing.OrderItem.Dto
{
    [AutoMap(typeof(UltimateInvocing.Models.OrderItem))]
    public class OrderItemDto : EntityDto<Guid>
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

        public OrderDto Order { get; set; }
        public Guid OrderId { get; set; }
    }
}
