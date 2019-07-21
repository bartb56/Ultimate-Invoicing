using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Factories.Order;
using UltimateInvocing.Order.Dto;

namespace UltimateInvocing.Order
{
    public interface IOrderAppService : IApplicationService
    {
        Task<OrderListModel> GetAll();
        Task Create(OrderCreateModel orderCreateModel);
        Task Delete(Guid id);
        Task<OrderDto> GetById(Guid id);
        Task Update(Guid orderId);
        Task UpdateCustomerDetails(Guid orderId);
        Task UpdateCompanyDetails(Guid orderId);
    }
}
