using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Customers.Address;
using UltimateInvocing.Models;

namespace UltimateInvocing.Customers
{
    public class CustomerAppService : UltimateInvocingAppServiceBase, ICustomerAppService
    {  
        IRepository<Models.Customer, Guid> _repository;
        private readonly IAddressAppService _addressAppService;

        public CustomerAppService(IRepository<Models.Customer, Guid> repository,
            IAddressAppService addressAppService)
        {
            _repository = repository;
            _addressAppService = addressAppService;
        }

        public async Task Create(CustomerDto addressDto)
        {
            var customer = ObjectMapper.Map<Customer>(addressDto);
            await _repository.InsertAsync(customer);
            return;
        }

        public async Task Delete(Guid id)
        {
            var customer = await _repository.GetAll().Include(x => x.CustomerAddresses).FirstOrDefaultAsync(x => x.Id == id);

            foreach(var address in customer.CustomerAddresses)
            {
                await _addressAppService.Delete(address.Id);
            }

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
