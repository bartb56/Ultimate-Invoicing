using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateInvocing.Country.Dto;

namespace UltimateInvocing.Web.Models.Country
{
    public class EditCountryModalViewModel
    {
        public EditCountryModalViewModel(CountryDto output)
        {
            Id = output.Id;
            Name = output.Name;
            IsoCode = output.IsoCode;
            IsoCode3 = output.IsoCode3;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string IsoCode3 { get; set; }
    }
}
