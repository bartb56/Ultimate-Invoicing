using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UltimateInvocing.PaymentType.Dto
{
    [AutoMap(typeof(UltimateInvocing.Models.PaymentType))]
    public class PaymentTypeDto : EntityDto<Guid>
    {
        [Required]
        [MinLength(2)]
        [MaxLength(128)]
        public string TypeName { get; set; }
        [Required]
        public int DisplayOrder { get; set; }
    }
}
