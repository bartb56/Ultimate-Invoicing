using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Authorization;
using UltimateInvocing.PaymentType.Dto;

namespace UltimateInvocing.PaymentType
{
    [AbpAuthorize]
    [AbpAuthorize(PermissionNames.Pages_PaymentTypes)]
    public class PaymentTypeAppService : UltimateInvocingAppServiceBase, IPaymentTypeAppService
    {
        private readonly IRepository<Models.PaymentType, Guid> _repository;

        public PaymentTypeAppService(IRepository<Models.PaymentType, Guid> repository)
        {
            _repository = repository;
        }

        public async Task Create(PaymentTypeDto productDto)
        {
            var product = ObjectMapper.Map<Models.PaymentType>(productDto);
            await _repository.InsertAsync(product);
            return;
        }

        public async Task Delete(Guid id)
        {
            var product = _repository.Get(id);
            if (product != null)
            {
                await _repository.DeleteAsync(product);
            }
            return;
        }

        public async Task<List<PaymentTypeDto>> GetAll()
        {
            return ObjectMapper.Map<List<PaymentTypeDto>>(await _repository.GetAll().OrderBy(x => x.DisplayOrder).ToListAsync());
        }

        public async Task<PaymentTypeDto> GetById(Guid id)
        {
            return ObjectMapper.Map<PaymentTypeDto>(await _repository.GetAsync(id));
        }

        public async Task Update(PaymentTypeDto productDto)
        {
            var product = ObjectMapper.Map<Models.PaymentType>(productDto);
            await _repository.UpdateAsync(product);
            return;
        }
    }
}
