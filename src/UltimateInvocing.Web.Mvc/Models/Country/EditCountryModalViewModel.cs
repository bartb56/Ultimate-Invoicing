using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateInvocing.Attributes;
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
            DisplayOrder = output.DisplayOrder;
        }
        public Guid Id { get; set; }
        [UltimateResourceDisplayName("patatekes")]
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string IsoCode3 { get; set; }
        public int DisplayOrder { get; set; }
    }
}
