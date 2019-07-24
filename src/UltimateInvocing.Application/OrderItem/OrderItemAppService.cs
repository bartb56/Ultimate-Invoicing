using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Authorization;
using UltimateInvocing.OrderItem.Dto;

namespace UltimateInvocing.OrderItem
{
    [AbpAuthorize(PermissionNames.Pages_Orders)]
    public class OrderItemAppService : UltimateInvocingAppServiceBase, IOrderItemAppService
    {
        private readonly IRepository<Models.OrderItem, Guid> _repository;

        public OrderItemAppService(IRepository<Models.OrderItem, Guid> repository)
        {
            _repository = repository;
        }

        public async Task Create(OrderItemDto productDto)
        {
            var product = ObjectMapper.Map<Models.OrderItem>(productDto);
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

        public async Task<List<OrderItemDto>> GetAll()
        {
            return ObjectMapper.Map<List<OrderItemDto>>(await _repository.GetAllListAsync());
        }

        public async Task<List<OrderItemDto>> GetAllByOrderId(Guid orderId)
        {
            var orderItems = await _repository.GetAll().Where(x => x.OrderId == orderId).ToListAsync();
            return ObjectMapper.Map<List<OrderItemDto>>(orderItems);
        }

        public async Task<OrderItemDto> GetById(Guid id)
        {
            return ObjectMapper.Map<OrderItemDto>(await _repository.GetAsync(id));
        }

        public async Task Update(OrderItemDto productDto)
        {
            var product = ObjectMapper.Map<Models.OrderItem>(productDto);
            await _repository.UpdateAsync(product);
            return;
        }
}
}
