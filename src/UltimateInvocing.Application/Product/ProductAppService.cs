using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Authorization;
using UltimateInvocing.Product.Dto;

namespace UltimateInvocing.Product
{
    [AbpAuthorize(PermissionNames.Pages_Products)]
    public class ProductAppService : UltimateInvocingAppServiceBase, IProductAppService
    {
        private readonly IRepository<Models.Product, Guid> _repository;

        public ProductAppService(IRepository<Models.Product, Guid> repository)
        {
            _repository = repository;
        }

        public async Task Create(ProductDto productDto)
        {
            var product = ObjectMapper.Map<Models.Product>(productDto);
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

        public async Task<List<ProductDto>> GetAll()
        {
            return ObjectMapper.Map<List<ProductDto>>(await _repository.GetAllListAsync());
        }

        public async Task<ProductDto> GetById(Guid id)
        {
            return ObjectMapper.Map<ProductDto>(await _repository.GetAsync(id));
        }

        public async Task Update(ProductDto productDto)
        {
            var product = ObjectMapper.Map<Models.Product>(productDto);
            await _repository.UpdateAsync(product);
            return;
        }
    }
}
