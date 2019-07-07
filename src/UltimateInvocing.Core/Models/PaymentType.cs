using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UltimateInvocing.Models
{
    [Table("PaymentTypes")]
    public class PaymentType : Entity<Guid>
    {
        [Required]
        [MinLength(2)]
        [MaxLength(128)]
        public string TypeName { get; set; }
        [Required]
        public int DisplayOrder { get; set; }
    }
}
