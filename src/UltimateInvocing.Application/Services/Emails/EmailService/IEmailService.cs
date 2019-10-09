using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UltimateInvocing.Services.Emails.EmailService
{
    public interface IEmailAppService: IApplicationService
    {

        Task UpdateEmailSettings(Models.EmailSettings emailSettings);

        Task<string> SendOrderEmail(EmailOrder emailOrder);
    }
}
