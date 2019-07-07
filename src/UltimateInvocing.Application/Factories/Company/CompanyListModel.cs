using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using UltimateInvocing.Company.Dto;

namespace UltimateInvocing.Web.Factories.Company
{
    public class CompanyListModel
    {
        public List<CompanyDto> Companies { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> Provinces { get; set; }

    }
}