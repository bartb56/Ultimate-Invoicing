using System;
using System.Collections.Generic;
using System.Text;
using UltimateInvocing.Models;

namespace UltimateInvocing.Services.Email
{
    public interface IEmailService
    {
        EmailSettings GetEmailSettings();
    }
}
