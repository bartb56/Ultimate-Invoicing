using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Customers.Address.AddressDto;

namespace UltimateInvocing.Customers.Address
{
    public class AddressAppService : UltimateInvocingAppServiceBase, IAddressAppService
    {
        private readonly IRepository<Models.CustomerAddress, Guid> _repository;
        private readonly IRepository<Models.Address, Guid> _addressRepository;

        public AddressAppService(IRepository<Models.CustomerAddress, Guid> repository,
            IRepository<Models.Address, Guid> addressRepository)
        {
            _repository = repository;
            _addressRepository = addressRepository;
        }

        public async Task Create(AdressDTO addressDto)
        {
            var address = ObjectMapper.Map<Models.Address>(addressDto);
            var customerId = addressDto.CustomerId;

            var addressId = await _addressRepository.InsertAndGetIdAsync(address);
            var customerAddress = new Models.CustomerAddress()
            {
                AddressId = addressId,
                CustomerId = customerId
            };
            await _repository.InsertAsync(customerAddress);
            return;
        }

        public async Task Delete(Guid id)
        {
            var customerAddress = await _repository.GetAll().Include(x => x.Address).FirstOrDefaultAsync(x => x.AddressId == id);
            if(customerAddress == null)
            {
                return;
            }
            await _repository.DeleteAsync(customerAddress);
            await _addressRepository.DeleteAsync(customerAddress.Address);
        }

        public async Task<List<AdressDTO>> GetAllByUserId(Guid id)
        {
            return ObjectMapper.Map<List<AdressDTO>>(await _repository.GetAll().Where(x => x.CustomerId == id).Select(x => x.Address).Include(x => x.Product).Include(x => x.Province).ToListAsync());
        }

        public async Task<AdressDTO> GetById(Guid id)
        {
            return ObjectMapper.Map<AdressDTO>(await _addressRepository.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task Update(AdressDTO addressDto)
        {
            var address = ObjectMapper.Map<Models.Address>(addressDto);
            await _addressRepository.UpdateAsync(address);
            return;
        }
    }
}
