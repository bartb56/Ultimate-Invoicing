using Abp.Authorization;
using Abp.Domain.Services;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using UltimateInvocing.Authorization;

namespace UltimateInvocing.Services.Emails
{
    [AbpAuthorize]
    [AbpAuthorize(PermissionNames.Pages_Emails)]
    public class EmailSender : IDomainService
    {
        private readonly ISmtpEmailSender _emailSender;

        public EmailSender(ISmtpEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void Assign(Models.Order    person)
        {

            //Send a notification email
            _emailSender.Send(
                to: "bartblokhuis123@outlook.com",
                subject: "You have a new task!",
                body: $"A new task is assigned for you: <b></b>",
                isBodyHtml: true
            );
        }
    }
}
