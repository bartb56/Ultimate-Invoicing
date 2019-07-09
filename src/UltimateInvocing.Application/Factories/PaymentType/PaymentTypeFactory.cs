using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Factories.PaymentType.Models;
using UltimateInvocing.PaymentType;

namespace UltimateInvocing.Factories.PaymentType
{
    public class PaymentTypeFactory : IPaymentTypeFactory
    {
        private readonly IPaymentTypeAppService _appService;

        public PaymentTypeFactory(IPaymentTypeAppService appService)
        {
            _appService = appService;
        }

        public async Task<PaymentTypeViewModel> PrepareEditModel(Guid id)
        {
            var type = await _appService.GetById(id);
            if (type == null)
                throw new Exception("Not found");
            var model = new PaymentTypeViewModel()
            {
                DisplayOrder = type.DisplayOrder,
                TypeName = type.TypeName,
                Id = type.Id
            };
            return model;
        }

        public async Task<PaymentTypeListModel> PrepareListModel()
        {
            var model = new PaymentTypeListModel();
            model.PaymentTypes = await _appService.GetAll();
            return model;
        }
    }
}
