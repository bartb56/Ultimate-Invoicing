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

            int newProductStock = product.Stock - orderItem.Quantity;

            //Product stock is lower then 0
            if (newProductStock < 0)
                return;

            product.Stock = newProductStock;
            await _productAppService.UpdateStock(product.Stock, product.Id);

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

        public async Task UpdateProductDetails(Guid orderItemId)
        {
            var orderItem = await _repository.GetAsync(orderItemId);
            
            if (orderItem == null)
                throw new Exception("OrderItem not found.");

            var product = await _productAppService.GetById(orderItem.ProductId);
            if (product.Id == Guid.Empty)
                return;

            orderItem.Number = product.Number;
            orderItem.Price = product.Price;
            orderItem.ProductId = product.Id;
            orderItem.Description = product.Description;
            orderItem.Name = product.Name;
            orderItem.SKUCode = product.SKUCode;
            orderItem.Tax = product.Tax;
            orderItem.Weight = product.Weight;

            await _repository.UpdateAsync(orderItem);

            return;
        }

        public async Task Delete(Guid id)
        {
            var orderItem = _repository.Get(id);
            var productId = orderItem.ProductId;
            if(orderItem != null && productId != null)
            {
                var product = await _productAppService.GetById(productId);
                product.Stock += orderItem.Quantity;
                await _productAppService.UpdateStock(product.Stock, product.Id);
            }
            if (orderItem != null)
            {
                await _repository.DeleteAsync(orderItem);
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

        public async Task Update(OrderItemDto orderItemDto)
        {
            var orderItem = ObjectMapper.Map<Models.OrderItem>(orderItemDto);
            //Get last orderItem quantity, we use this to update the product stock.
            var originalOrderItem = await _repository.GetAsync(orderItem.Id);
            int originalQuantity = 0;
            if(originalOrderItem != null)
            {
                originalQuantity = originalOrderItem.Quantity;
            }
            await _repository.UpdateAsync(orderItem);

            var product = await _productAppService.GetById(orderItem.ProductId);
            if(product != null && originalQuantity != orderItem.Quantity)
            {
                if(originalQuantity > orderItem.Quantity)
                {
                    //The original quantity was higher so we must readd some of the stock
                    product.Stock += (originalQuantity - orderItem.Quantity);
                }
                else
                {
                    product.Stock += (orderItem.Quantity - originalQuantity);
                }
                await _productAppService.UpdateStock(product.Stock, product.Id);
            }
            return;
        }
    }
}
