using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Customers;
using UltimateInvocing.Customers.Address;
using UltimateInvocing.Customers.Address.AddressDto;
using UltimateInvocing.Order;

namespace UltimateInvocing.Factories.Order
{
    public class OrderFactory : IOrderFactory
    {
        private readonly IOrderAppService _appService;
        private readonly IAddressAppService _addressAppService;
        private readonly ICustomerAppService _customerAppService;

        public OrderFactory(IOrderAppService appService,
            IAddressAppService addressAppService,
            ICustomerAppService customerAppService)
        {
            _appService = appService;
            _addressAppService = addressAppService;
            _customerAppService = customerAppService;
        }

        public async Task<OrderListModel> PrepareListModel()
        {
            var model = await _appService.GetAll();
            return model;
        }

        public async Task<List<AdressDTO>> UpdateAddressByCustomerId(Guid customerId)
        {
            return await _addressAppService.GetAllByCustomerId(customerId);
        }

        public async Task UpdateCompanyDetails(Guid orderId)
        {
            await _appService.UpdateCompanyDetails(orderId);
            return;
        }

        public async Task UpdateCustomerDetails(Guid orderId)
        {
            await _appService.UpdateCustomerDetails(orderId);
            return;
        }
    }
}
