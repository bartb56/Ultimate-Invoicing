using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.PaymentType.Dto;

namespace UltimateInvocing.PaymentType
{
    public interface IPaymentTypeAppService : IApplicationService
    {
        Task<List<PaymentTypeDto>> GetAll();
        Task Create(PaymentTypeDto productDto);
        Task Delete(Guid id);
        Task<PaymentTypeDto> GetById(Guid id);
        Task Update(PaymentTypeDto productDto);
    }
}
