using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateInvocing.Customers;

namespace UltimateInvocing.Web.Models.Customer
{
    public class CustomerListModel
    {
        public IReadOnlyList<CustomerDto> Customers { get; set; }
    }
}
