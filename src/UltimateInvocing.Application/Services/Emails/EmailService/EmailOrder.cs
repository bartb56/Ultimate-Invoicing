using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateInvocing.Services.Emails.EmailService
{
    public class EmailOrder
    {
        public Guid emailTemplateId { get; set; }

        public Guid orderId { get; set; }
    }
}
