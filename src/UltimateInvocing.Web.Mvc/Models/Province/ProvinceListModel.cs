using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateInvocing.Country.Dto;
using UltimateInvocing.Province.Dto;

namespace UltimateInvocing.Web.Models.Province
{
    public class ProvinceListModel
    {
        public IReadOnlyList<ProvinceDto> Provinces { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}
