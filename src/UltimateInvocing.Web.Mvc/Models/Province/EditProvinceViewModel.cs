using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateInvocing.Province.Dto;

namespace UltimateInvocing.Web.Models.Province
{
    public class EditProvinceViewModel
    {
        public EditProvinceViewModel(ProvinceDto output)
        {
            Id = output.Id;
            Name = output.Name;
            CountryId = output.CountryId;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}
