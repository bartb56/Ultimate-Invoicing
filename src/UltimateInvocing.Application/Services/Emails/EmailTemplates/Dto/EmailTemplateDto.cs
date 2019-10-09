using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UltimateInvocing.Models;

namespace UltimateInvocing.Services.Emails.EmailTemplates.Dto
{
    [AutoMap(typeof(UltimateInvocing.Models.EmailTemplate))]
    public class EmailTemplateDto : EntityDto<Guid>
    {
        public bool IsActive { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Models.Company Company { get; set; }

        public string HtmlContent { get; set; }

        public TemplateTypes TemplateType { get; set; }

        public string Name { get; set; }

        public int DisplayOrder { get; set; } = 0;
    }
}
