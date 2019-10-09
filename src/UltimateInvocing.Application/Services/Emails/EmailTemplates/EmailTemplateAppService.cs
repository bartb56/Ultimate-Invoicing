using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Authorization;
using UltimateInvocing.Services.Emails.EmailTemplates.Dto;

namespace UltimateInvocing.Services.Emails.EmailTemplates
{
    [AbpAuthorize]
    [AbpAuthorize(PermissionNames.Pages_Emails)]
    public class EmailTemplateAppService : UltimateInvocingAppServiceBase, IEmailTemplateAppService
    {
        private readonly IRepository<Models.EmailTemplate, Guid> _repository;

        public EmailTemplateAppService(IRepository<Models.EmailTemplate, Guid> repository)
        {
            _repository = repository;
        }

        public async Task Create(EmailTemplateDto emailTemplateDto)
        {
            var emailTemplate = ObjectMapper.Map<Models.EmailTemplate>(emailTemplateDto);

            var splittedHtmlContent = emailTemplateDto.HtmlContent.Split("<img src=\"");

            await _repository.InsertAsync(emailTemplate);
            return;
        }

        public async Task Delete(Guid id)
        {
            var emailTemplate = _repository.Get(id);
            if (emailTemplate != null)
            {
                await _repository.DeleteAsync(emailTemplate);
            }
            return;
        }

        public async Task<List<EmailTemplateDto>> GetAll()
        {
            var emailTemplates = await _repository.GetAll().ToListAsync();
            return ObjectMapper.Map<List<EmailTemplateDto>>(emailTemplates);
        }

        public async Task<EmailTemplateDto> GetById(Guid id)
        {
            return ObjectMapper.Map<EmailTemplateDto>(await _repository.GetAsync(id));
        }
    }
}
