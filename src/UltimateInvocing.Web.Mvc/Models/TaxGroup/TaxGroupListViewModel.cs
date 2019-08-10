using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateInvocing.Services.TaxGroups.Dto;

namespace UltimateInvocing.Web.Models.TaxGroup
{
    public class TaxGroupListViewModel
    {
        public IReadOnlyList<TaxGroupDto> TaxGroups { get; set; }
    }
}
