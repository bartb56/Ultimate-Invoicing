using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Factories.PaymentType.Models;

namespace UltimateInvocing.Factories.PaymentType
{
    public interface IPaymentTypeFactory
    {
        Task<PaymentTypeListModel> PrepareListModel();
        Task<PaymentTypeViewModel> PrepareEditModel(Guid id);
    }
}
