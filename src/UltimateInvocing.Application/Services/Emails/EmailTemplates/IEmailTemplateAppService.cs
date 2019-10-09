using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Services.Emails.EmailTemplates.Dto;

namespace UltimateInvocing.Services.Emails.EmailTemplates
{
    public interface IEmailTemplateAppService : IApplicationService
    {
        Task<List<EmailTemplateDto>> GetAll();
        Task Create(EmailTemplateDto emailTemplateDto);
        Task Delete(Guid id);
        Task<EmailTemplateDto> GetById(Guid id);
    }
}
