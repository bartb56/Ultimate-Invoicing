using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Models;

namespace UltimateInvocing.Customers
{
    public class CustomerAppService : UltimateInvocingAppServiceBase, ICustomerAppService
    {  
        IRepository<Models.Customer, Guid> _repository;

        public CustomerAppService(IRepository<Models.Customer, Guid> repository)
        {
            _repository = repository;
        }

        public async Task Create(CustomerDto addressDto)
        {
            var customer = ObjectMapper.Map<Customer>(addressDto);
            await _repository.InsertAsync(customer);
            return;
        }

        public async Task Delete(Guid id)
        {
            var customer = await _repository.FirstOrDefaultAsync(x => x.Id == id);
            await _repository.DeleteAsync(customer);
            return;
        }

        public async Task<List<CustomerDto>> GetAll()
        {
            return ObjectMapper.Map<List<CustomerDto>>(await _repository.GetAll().Include(x => x.CustomerAddresses).ToListAsync());
        }

        public async Task<CustomerDto> GetById(Guid id)
        {
            return ObjectMapper.Map<CustomerDto>(await _repository.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task Update(CustomerDto addressDto)
        {
            var customer = ObjectMapper.Map<Customer>(addressDto);
            await _repository.UpdateAsync(customer);
            return;
        }
    }
}
