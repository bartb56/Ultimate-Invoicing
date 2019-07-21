using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Product.Dto;

namespace UltimateInvocing.Product
{
    public interface IProductAppService : IApplicationService
    {
        Task<List<ProductDto>> GetAll();
        Task Create(ProductDto productDto);
        Task Delete(Guid id);
        Task<ProductDto> GetById(Guid id);
        Task Update(ProductDto productDto);

        Task<int> HighestProductNumber();
    }
}
