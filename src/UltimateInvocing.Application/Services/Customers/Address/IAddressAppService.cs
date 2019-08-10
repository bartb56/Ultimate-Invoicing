using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Customers.Address.AddressDto;

namespace UltimateInvocing.Customers.Address
{
    public interface IAddressAppService : IApplicationService
    {
        Task<List<AdressDTO>> GetAllByCustomerId(Guid id);
        Task<List<AdressDTO>> GetAllByCustomerIdIncluding(Guid id);
        Task Create(AdressDTO addressDto);
        Task Update(AdressDTO addressDto);
        Task Delete(Guid id);
        Task<AdressDTO> GetById(Guid id);
        


    }
}
