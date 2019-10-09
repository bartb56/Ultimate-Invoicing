using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UltimateInvocing.Factories.EmailTemplates
{
    public interface IEmailTemplateFactory
    {
        Task<EmailTemplateListModel> PrepareListModel();
    }
}
