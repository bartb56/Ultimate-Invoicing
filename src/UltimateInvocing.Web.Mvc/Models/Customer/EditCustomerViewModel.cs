using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UltimateInvocing.Customers;

namespace UltimateInvocing.Web.Models.Customer
{
    public class EditCustomerViewModel
    {
        public EditCustomerViewModel(CustomerDto dto)
        {
            Id = dto.Id;
            CompanyName = dto.CompanyName;
            CompanyEmail = dto.CompanyEmail;
            CompanyPhonenumber = dto.CompanyPhonenumber;
            Number = dto.Number;
        }
        public Guid Id { get; set; }

        [Required()]
        public int Number { get; set; }

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
    }
}
