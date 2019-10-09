using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Abp.Net.Mail.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UltimateInvocing.Models;
using UltimateInvocing.Settings;

namespace UltimateInvocing.Services.Email
{
    public class EmailService : IDomainService, IEmailService
    {
        private readonly IRepository<Models.EmailSettings, Guid> _repository;
        private readonly ISmtpEmailSender _smtpEmailSender;
        ISmtpEmailSenderConfiguration _smtpEmailSenderConfiguration;

        public EmailService(IRepository<Models.EmailSettings, Guid> repository,
            ISmtpEmailSender smtpEmailSender,
            ISmtpEmailSenderConfiguration smtpEmailSenderConfiguration)
        {
            _repository = repository;
            _smtpEmailSender = smtpEmailSender;
            _smtpEmailSenderConfiguration = smtpEmailSenderConfiguration;
        }

        [UnitOfWork]
        public virtual EmailSettings GetEmailSettings()
        {
            var allSettings = _repository.GetAll();

            return allSettings.First();
        }

        protected void BuildClient()
        {
            var client = new SmtpEmailSender(_smtpEmailSenderConfiguration).BuildClient();
        }
    }
}
