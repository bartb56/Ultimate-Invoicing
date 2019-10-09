using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Company;
using System.Linq;
using UltimateInvocing.Services.Emails.EmailTemplates;
using UltimateInvocing.Models;

namespace UltimateInvocing.Factories.EmailTemplates
{
    public class EmailTemplateFactory : IEmailTemplateFactory
    {
        private readonly IEmailTemplateAppService _appService;
        private readonly ICompanyAppService _companyAppService; 

        public EmailTemplateFactory(IEmailTemplateAppService appService,
            ICompanyAppService companyAppService)
        {
            _appService = appService;
            _companyAppService = companyAppService;
        }

        public async Task<EmailTemplateListModel> PrepareListModel()
        {

            var model = new EmailTemplateListModel() { EmailTemplateDtos = await _appService.GetAll() };

            var companies = await _companyAppService.GetAll();
            if (companies.Any())
                model.Companies = companies.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();

            var values = Enum.GetValues(typeof(TemplateTypes)).Cast<TemplateTypes>();

            model.EmailTemplateTypes = values.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = x.ToString(), Text = x.ToString() }).ToList();
            return model;
        }
    }
}
