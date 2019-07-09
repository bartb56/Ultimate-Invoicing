using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UltimateInvocing.Factories.PaymentType.Models
{
    public class PaymentTypeViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(128)]
        public string TypeName { get; set; }
        [Required]
        public int DisplayOrder { get; set; }

        public Guid Id;
    }
}
