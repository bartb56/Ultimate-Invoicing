using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            DisplayOrder = output.DisplayOrder;
        }
        public Guid Id { get; set; }
        [Required()]
        public string Name { get; set; }
        [Required()]
        public Guid CountryId { get; set; }

        [Required()]
        public int DisplayOrder { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}
