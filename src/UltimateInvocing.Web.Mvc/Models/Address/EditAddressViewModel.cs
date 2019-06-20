using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateInvocing.Customers.Address.AddressDto;

namespace UltimateInvocing.Web.Models.Address
{
    public class EditAddressViewModel
    {
        public EditAddressViewModel(AdressDTO address)
        {
            Id = address.Id;
            CountryId = address.CountryId;
            ProvinceId = address.ProvinceId;
            City = address.City;
            StreetAddress = address.StreetAddress;
            HouseNumber = address.HouseNumber;
            PostalCode = address.PostalCode;
            PhoneNumber = address.PhoneNumber;
            Taxable = address.Taxable;
        }
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public Guid ProvinceId { get; set; }

        public string City { get; set; }

        public string StreetAddress { get; set; }

        public string HouseNumber { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public bool Taxable { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> Provinces { get; set; }
    }
}
