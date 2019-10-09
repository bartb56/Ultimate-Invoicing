using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using UltimateInvocing.Services.Emails.EmailTemplates.Dto;

namespace UltimateInvocing.Factories.EmailTemplates
{
    public class EmailTemplateListModel
    {
        public List<EmailTemplateDto> EmailTemplateDtos { get; set; }

        public List<SelectListItem> Companies { get; set; }
        public List<SelectListItem> EmailTemplateTypes { get; set; }
    }
}
