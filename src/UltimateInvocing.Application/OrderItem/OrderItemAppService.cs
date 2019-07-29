using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Authorization;
using UltimateInvocing.Factories.OrderItems;
using UltimateInvocing.Order;
using UltimateInvocing.OrderItem.Dto;
using UltimateInvocing.Product;

namespace UltimateInvocing.OrderItem
{
    [AbpAuthorize(PermissionNames.Pages_Orders)]
    public class OrderItemAppService : UltimateInvocingAppServiceBase, IOrderItemAppService
    {
        private readonly IRepository<Models.OrderItem, Guid> _repository;
        private readonly IProductAppService _productAppService;
        private readonly IOrderAppService _orderAppService;

        public OrderItemAppService(IRepository<Models.OrderItem, Guid> repository,
            IProductAppService productAppService,
            IOrderAppService orderAppService)
        {
            _repository = repository;
            _productAppService = productAppService;
            _orderAppService = orderAppService;
        }

        public async Task Create(OrderItemCreateModel orderItem)
        {
            if (orderItem.OrderId == null || await _orderAppService.GetById(orderItem.OrderId) == null)
                throw new Exception("Order not found");

            if (orderItem.ProductId == null)
                throw new Exception("No product given");
            var product = await _productAppService.GetById(orderItem.ProductId);

            if (product == null)
                throw new Exception("No product match has been found.");

            Models.OrderItem newOrderItem = new Models.OrderItem()
            {
                Number = product.Number,
                Price = product.Price,
                ProductId = product.Id,
                Description = product.Description,
                Name = product.Name,
                OrderId = orderItem.OrderId,
                Quantity = orderItem.Quantity,
                SKUCode = product.SKUCode,
                Tax = product.Tax,
                Weight = product.Weight
            };
            await _repository.InsertAsync(newOrderItem);
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
