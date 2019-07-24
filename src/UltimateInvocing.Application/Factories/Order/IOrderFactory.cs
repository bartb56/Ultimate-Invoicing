using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Customers.Address.AddressDto;

namespace UltimateInvocing.Factories.Order
{
    public interface IOrderFactory
    {
        Task<OrderListModel> PrepareListModel();
        Task<OrderListModel> PrepareEditModel(Guid orderId);
        Task<List<AdressDTO>> UpdateAddressByCustomerId(Guid customerId);
        Task UpdateCustomerDetails(Guid orderId);
        Task UpdateCompanyDetails(Guid orderId);

    }
}
