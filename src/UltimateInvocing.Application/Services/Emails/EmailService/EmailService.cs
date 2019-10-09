using Abp.Authorization;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Net.Mail.Smtp;
using System;
using System.Linq;
using System.Threading.Tasks;
using UltimateInvocing.Authorization;
using UltimateInvocing.Models;
using UltimateInvocing.Order;
using UltimateInvocing.Services.Emails.EmailTemplates;

namespace UltimateInvocing.Services.Emails.EmailService
{
    [AbpAuthorize]
    [AbpAuthorize(PermissionNames.Pages_Emails)]
    public class EmailAppService : IEmailAppService
    {
        private readonly ISettingManager _settingManager;
        IRepository<Models.EmailSettings, Guid> _repository;
        private readonly IEmailTemplateAppService _emailTemplateAppService;
        private readonly ISmtpEmailSender _smtpEmailSender;
        private readonly IOrderAppService _orderAppService;

        public EmailAppService(ISettingManager settingManager,
            IRepository<Models.EmailSettings, Guid> repository,
            ISmtpEmailSender smtpEmailSender,
            IEmailTemplateAppService emailTemplateAppService,
            IOrderAppService orderAppService)
        {
            _settingManager = settingManager;
            _repository = repository;
            _smtpEmailSender = smtpEmailSender;
            _emailTemplateAppService = emailTemplateAppService;
            _orderAppService = orderAppService;
        }

        public async Task<string> SendOrderEmail(EmailOrder emailOrder)
        {
            var order = await _orderAppService.GetById(emailOrder.orderId);
            var emailTypes = await _emailTemplateAppService.GetAll();
            var emailType = emailTypes.FirstOrDefault(x => x.Id == emailOrder.emailTemplateId);
            try
            {
                await _smtpEmailSender.SendAsync(
                    to: order.CustomerCompanyEmail,
                    subject: "You have a new Order!",
                    body: emailType.HtmlContent,
                    isBodyHtml: true);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return "patat";
        }

        public async Task UpdateEmailSettings(EmailSettings emailSettings)
        {
            await _settingManager.ChangeSettingForApplicationAsync("Abp.Net.Mail.DefaultFromAddress", emailSettings.DefaultFromAddress);
            await _settingManager.ChangeSettingForApplicationAsync("Abp.Net.Mail.Smtp.Host", emailSettings.Host);
            await _settingManager.ChangeSettingForApplicationAsync("Abp.Net.Mail.Smtp.Port", emailSettings.Port);
            await _settingManager.ChangeSettingForApplicationAsync("Abp.Net.Mail.DefaultFromDisplayName", emailSettings.DefaultFromDisplayName);
            await _settingManager.ChangeSettingForApplicationAsync("Abp.Net.Mail.Smtp.UserName", emailSettings.UserName);
            await _settingManager.ChangeSettingForApplicationAsync("Abp.Net.Mail.Smtp.Password", emailSettings.Password);
            //_settingManager.ChangeSettingForApplicationAsync("Abp.Net.Mail.Smtp.EnableSsl", emailSettings.EnableSsl);
            var settings = await _repository.GetAllListAsync();
            settings.First().Id = emailSettings.Id;
            await _repository.UpdateAsync(emailSettings);
            return;
        }
    }
}
