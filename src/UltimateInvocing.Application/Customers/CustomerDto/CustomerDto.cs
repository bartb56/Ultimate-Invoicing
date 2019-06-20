using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UltimateInvocing.Models;

namespace UltimateInvocing.Customers
{
    [AutoMap(typeof(UltimateInvocing.Models.Customer))]
    public class CustomerDto : EntityDto<Guid>
    {
        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string CompanyName { get; set; }

        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string CompanyEmail { get; set; }

        [Required()]
        [MinLength(2)]
        [MaxLength(128)]
        public string CompanyPhonenumber { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
