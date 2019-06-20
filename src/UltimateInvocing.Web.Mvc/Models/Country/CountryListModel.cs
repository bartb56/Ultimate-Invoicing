using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateInvocing.Country.Dto;

namespace UltimateInvocing.Web.Models.Country
{
    public class CountryListModel
    {
        public IReadOnlyList<CountryDto> Countries { get; set; }
    }
}
