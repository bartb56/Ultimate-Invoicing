using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Company;
using UltimateInvocing.Customers;
using UltimateInvocing.Customers.Address;
using UltimateInvocing.Customers.Address.AddressDto;
using UltimateInvocing.Order;
using UltimateInvocing.Order.Dto;
using UltimateInvocing.PaymentType;
using UltimateInvocing.Services.Emails.EmailTemplates;

namespace UltimateInvocing.Factories.Order
{
    public class OrderFactory : IOrderFactory
    {
        private readonly IOrderAppService _appService;
        private readonly IAddressAppService _addressAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly ICompanyAppService _companyAppService;
        private readonly IPaymentTypeAppService _paymentTypeAppService;
        private readonly IEmailTemplateAppService _emailTemplateAppService;

        public OrderFactory(IOrderAppService appService,
            IAddressAppService addressAppService,
            ICustomerAppService customerAppService,
            ICompanyAppService companyAppService,
            IPaymentTypeAppService paymentTypeAppService,
            IEmailTemplateAppService emailTemplateAppService)
        {
            _appService = appService;
            _addressAppService = addressAppService;
            _customerAppService = customerAppService;
            _companyAppService = companyAppService;
            _paymentTypeAppService = paymentTypeAppService;
            _emailTemplateAppService = emailTemplateAppService;
        }

        public async Task<OrderListModel> PrepareEditModel(Guid orderId)
        {
            var model = new OrderListModel();
            var order = await _appService.GetById(orderId);
            model.OrderId = orderId;
            model.NewOrderNumber = order.Number;
            var customers = await _customerAppService.GetAll();
            model.Customers = customers.Select(x => new SelectListItem { Text = x.CustomerName, Value = x.Id.ToString() }).ToList();
            model.Customers.FirstOrDefault(x => x.Value == order.CustomerId.ToString()).Selected = true;

            var companies = await _companyAppService.GetAll();
            model.Companies = companies.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            model.Companies.FirstOrDefault(x => x.Value == order.CompanyId.ToString()).Selected = true;

            //ISSUE
            var address = await _addressAppService.GetAllByCustomerId(order.CustomerId);    
            model.Addresses = address.Select(x => new SelectListItem { Text = x.StreetAddress, Value = x.Id.ToString() }).ToList();
            model.Addresses.FirstOrDefault(x => x.Value == order.CustomerAddressId.ToString()).Selected = true;

            var paymentTypes = await _paymentTypeAppService.GetAll();
            model.PaymentTypes = paymentTypes.Select(x => new SelectListItem { Text = x.TypeName, Value = x.Id.ToString() }).ToList();
            model.PaymentTypes.FirstOrDefault(x => x.Value == order.PaymentTypeId.ToString()).Selected = true;     
           
            return model;
        }

        public async Task<OrderListModel> PrepareListModel()
        {
            var model = await _appService.GetAll();

            var emailTemplates = await _emailTemplateAppService.GetAll();
            model.EmailTemplates = emailTemplates.Where(x => x.IsActive == true).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

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
