using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using UltimateInvocing.Customers.Address.AddressDto;

namespace UltimateInvocing.Web.Models.Address
{
    public class AddressListModel
    {
        public Guid CustomerId { get; set; }
        public IReadOnlyList<AdressDTO> Addresses { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> Provinces { get; set; }
    }
}
