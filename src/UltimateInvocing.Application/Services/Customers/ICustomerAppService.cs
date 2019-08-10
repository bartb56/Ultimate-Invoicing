using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UltimateInvocing.Customers
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<List<CustomerDto>> GetAll();
        Task Create(CustomerDto addressDto);
        Task Update(CustomerDto addressDto);
        Task Delete(Guid id);
        Task<CustomerDto> GetById(Guid id);
      
    }
}
