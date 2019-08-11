using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UltimateInvocing.Services.TaxGroups.Dto;

namespace UltimateInvocing.Web.Models.TaxGroup
{
    public class EditTaxGroupViewModel
    {
        [Required()]
        public Guid Id { get; set; }
        [Required()]
        public string Name { get; set; }
        [Required()]
        public int Percentage { get; set; }
        [Required()]
        public int DisplayOrder { get; set; }

        public EditTaxGroupViewModel(TaxGroupDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Percentage = dto.Percentage;
            DisplayOrder = dto.DisplayOrder;
        }
    }
}
