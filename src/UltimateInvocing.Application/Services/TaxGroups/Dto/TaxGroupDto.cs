using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UltimateInvocing.Services.TaxGroups.Dto
{
    [AutoMap(typeof(Models.TaxGroup))]
    public class TaxGroupDto : EntityDto<Guid>
    {
        public TaxGroupDto() { }

        [Required()]
        public string Name { get; set; }
        [Required()]
        public int Percentage { get; set; }
        [Required()]
        public int DisplayOrder { get; set; }
    }
}
