using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Company;
using UltimateInvocing.Customers;
using UltimateInvocing.Customers.Address;
using UltimateInvocing.Factories.Order;
using UltimateInvocing.Order.Dto;
using UltimateInvocing.PaymentType;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web.Mvc;
using Newtonsoft.Json;
using UltimateInvocing.Services.Order.Dto;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Domain.Services;
using Abp.Configuration;
using UltimateInvocing.Services.Emails.EmailTemplates;
using Abp.Authorization;
using UltimateInvocing.Authorization;

namespace UltimateInvocing.Order
{
    [AbpAuthorize]
    [AbpAuthorize(PermissionNames.Pages_Orders)]
    public class OrderAppService : UltimateInvocingAppServiceBase, IOrderAppService, IDomainService
    {

        #region Fields
        IRepository<Models.Order, Guid> _repository;
        private readonly ICustomerAppService _customerAppService;
        private readonly ICompanyAppService _companyAppService;
        private readonly IPaymentTypeAppService _paymentTypeAppService;
        private readonly IAddressAppService _addressAppService;
        private readonly ISmtpEmailSenderConfiguration _smtpConfig;
        private readonly ISmtpEmailSender _smtpEmailSender;
        private readonly ISettingManager _settingManager;
        private readonly IEmailTemplateAppService _emailTemplateAppService;
        #endregion

        #region Constructor
        public OrderAppService(
            IRepository<Models.Order, Guid> repository,
            ICustomerAppService customerAppService,
            ICompanyAppService companyAppService,
            IPaymentTypeAppService paymentTypeAppService,
            IAddressAppService addressAppService,
            ISmtpEmailSenderConfiguration smtpConfig,
            ISmtpEmailSender smtpEmailSender,
            ISettingManager settingManager,
            IEmailTemplateAppService emailTemplateAppService)
        {
            _repository = repository;
            _customerAppService = customerAppService;
            _companyAppService = companyAppService;
            _paymentTypeAppService = paymentTypeAppService;
            _addressAppService = addressAppService;
            _smtpConfig = smtpConfig;
            _smtpEmailSender = smtpEmailSender;
            _settingManager = settingManager;
            _emailTemplateAppService = emailTemplateAppService;
        }
        #endregion

        #region Methods

        #region Common

        /// <summary>
        /// Gets all the orders
        /// </summary>
        /// <returns>List of orders</returns>
        public async Task<OrderListModel> GetAll()
        { 
            var model = new OrderListModel();

            //Get all orders and sort them on creation date / time
            var orders = await _repository.GetAll().ToListAsync();
            model.orders = ObjectMapper.Map<List<OrderDto>>(orders.OrderByDescending(x => x.OrderCreationtTime).ToList());

            //The create model is in the same view as the index page,
            //We want to create the next order number here.
            var numbers = model.orders.Select(x => x.Number).ToList();
            model.NewOrderNumber = GetNextOrderNumber(numbers);

            //Initialize the drop down list elements.
            model.Customers = await Customers();
            model.Addresses = await Addresses(model.Customers);
            model.Companies = await Companies();
            model.PaymentTypes = await PaymentTypes();
            
            return model;
        }

        /// <summary>
        /// Create a new order
        /// </summary>
        /// <param name="orderCreateModel"></param>
        /// <returns></returns>
        public async Task<Guid> Create(OrderCreateModel orderCreateModel)
        {
            var customer = await _customerAppService.GetById(orderCreateModel.CustomerId);
            var company = await _companyAppService.GetById(orderCreateModel.CompanyId);
            var paymentType = await _paymentTypeAppService.GetById(orderCreateModel.PaymentMethodId);
            var address = await _addressAppService.GetById(orderCreateModel.AddressId);
            if (paymentType == null || customer == null || company == null || address == null)
                throw new Exception("An error has occurred please try again.");

            //Generate the order
            OrderDto model = new OrderDto(orderCreateModel, customer, company, address, paymentType);
          
            //We return the id so we can redirect to the orderitem page.
            return await _repository.InsertAndGetIdAsync(ObjectMapper.Map<Models.Order>(model));
        }

        /// <summary>
        /// Update the order
        /// </summary>
        /// <param name="orderCreateModel"></param>
        /// <returns></returns>
        public async Task Update(OrderCreateModel orderCreateModel)
        {
            var order = await _repository.GetAsync(orderCreateModel.OrderId);
            if (order == null)
                throw new Exception("Order not found");

            var customer = await _customerAppService.GetById(orderCreateModel.CustomerId);
            var company = await _companyAppService.GetById(orderCreateModel.CompanyId);
            var paymentType = await _paymentTypeAppService.GetById(orderCreateModel.PaymentMethodId);
            var address = await _addressAppService.GetById(orderCreateModel.AddressId);
            if (paymentType == null || customer == null || company == null || address == null)
                throw new Exception("An error has occurred please try again.");

            order.Number = orderCreateModel.Number;
            //Company section
            order.CompanyBTW = company.BTW;
            order.CompanyCity = company.City;
            order.CompanyCountryName = company.Country.Name;
            order.CompanyHouseNumber = company.HouseNumber;
            order.CompanyIBAN = company.IBAN;
            order.CompanyKVK = company.KVK;
            order.CompanyLogo = company.Logo;
            order.CompanyName = company.Name;
            order.CompanyPhoneNumber = company.PhoneNumber;
            order.CompanyId = company.Id;
            order.CompanyPostalCode = company.PostalCode;
            order.CompanyProvinceName = company.Province.Name;
            order.CompanyStreetAddress = company.StreetAddress;

            //Customer section
            order.CustomerCity = address.City;
            order.CustomerCompanyEmail = customer.CustomerEmail;
            order.CustomerCompanyName = customer.CustomerName;
            order.CustomerCompanyPhonenumber = company.PhoneNumber;
            order.CustomerCountryName = address.Country.Name;
            order.CustomerHouseNumber = address.HouseNumber;
            order.CustomerPhoneNumber = address.PhoneNumber;
            order.CustomerPostalCode = address.PostalCode;
            order.CustomerProvinceName = address.Province.Name;
            order.CustomerStreetAddress = address.StreetAddress;
            order.CustomerTaxable = address.Taxable;
            order.CustomerId = customer.Id;
            order.CustomerAddressId = orderCreateModel.AddressId;


            //Payment type section
            order.PaymentTypeName = paymentType.TypeName;
            order.PaymentTypeId = paymentType.Id;

            await _repository.UpdateAsync(order);

            return;
        }

        /// <summary>
        /// Delete the order
        /// </summary>
        /// <param name="id">OrderId</param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            await _repository.DeleteAsync(await _repository.GetAll().Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == id));
        }

        /// <summary>
        /// Get the order by orderId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OrderDto> GetById(Guid id)
        {
            return ObjectMapper.Map<OrderDto>(await _repository.GetAll().Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == id));
        }
        #endregion

        #region Additional

        public async Task UpdateCustomerDetails(Guid orderId)
        {
            var order = await _repository.GetAsync(orderId);

            var customer = await _customerAppService.GetById(order.CustomerId);
            var address = await _addressAppService.GetById(order.CustomerAddressId);

            if (address != null)
            {
                order.CustomerCompanyPhonenumber = address.PhoneNumber;
                order.CustomerCountryName = address.Country.Name;
                order.CustomerHouseNumber = address.HouseNumber;
                order.CustomerPhoneNumber = address.PhoneNumber;
                order.CustomerPostalCode = address.PostalCode;
                order.CustomerProvinceName = address.Province.Name;
                order.CustomerStreetAddress = address.StreetAddress;
                order.CustomerTaxable = address.Taxable;
            }
            if (customer != null)
            {
                order.CustomerCompanyEmail = customer.CustomerEmail;
                order.CustomerCompanyName = customer.CustomerName;
                order.CustomerCity = address.City;
            }

            await _repository.UpdateAsync(order);
            return;
        }

        public async Task UpdateCompanyDetails(Guid orderId)
        {
            //Get the order
            var order = await _repository.GetAsync(orderId);

            //Validation
            if (order == null)
                throw new Exception("Order not found");
            if (order.CompanyId == null || order.CompanyId == Guid.Empty)
                throw new Exception("No company id registered");

            //Get the company
            var company = await _companyAppService.GetById(order.CompanyId);
            if (company == null)
                throw new Exception("No company found with the given identifier.");

            //Update the data
            order.CompanyBTW = company.BTW;
            order.CompanyCity = company.City;
            order.CompanyCountryName = company.Country.Name;
            order.CompanyHouseNumber = company.HouseNumber;
            order.CompanyIBAN = company.IBAN;
            order.CompanyKVK = company.KVK;
            order.CompanyLogo = company.Logo;
            order.CompanyName = company.Name;
            order.CompanyPhoneNumber = company.PhoneNumber;
            order.CompanyPostalCode = company.PostalCode;
            order.CompanyProvinceName = company.Province.Name;
            order.CompanyStreetAddress = company.StreetAddress;

            //Save changes
            await _repository.UpdateAsync(order);
            return;
        }

        public async Task<OrderListModel> GetLastOrders(int amount)
        {
            if (amount == 0)
                throw new Exception("Amount can not be 0");

            var model = new OrderListModel();

            var orders = await _repository.GetAll().OrderByDescending(x => x.OrderCreationtTime).ToListAsync();
            orders = orders.Take(amount).ToList();
            model.orders = ObjectMapper.Map<List<OrderDto>>(orders);

            var numbers = model.orders.Select(x => x.Number).ToList();
            model.NewOrderNumber = GetNextOrderNumber(numbers);
           

            model.Customers = await Customers();
            model.Addresses = await Addresses(model.Customers);
            model.Companies = await Companies();
            model.PaymentTypes = await PaymentTypes();
            return model;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Makes a select list of customers
        /// </summary>
        /// <returns>SelectList of customers</returns>
        private async Task<List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>> Customers()
        {
            var customers = await _customerAppService.GetAll();
            if (customers.Any())
                return customers.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.CustomerName, Value = x.Id.ToString() }).ToList();

            //Since i rather have an empty list vs a null reference error we return a empty list.
            return new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        }

        /// <summary>
        /// Makes a select list of addresses
        /// </summary>
        /// <returns>SelectList of addresses</returns>
        private async Task<List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>> Addresses(List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> customers)
        {
            //Make sure we have customers.
            if (customers.Any())
            {
                var firstAddresses = await _addressAppService.GetAllByCustomerId(new Guid(customers.First().Value));
                if (firstAddresses.Any())
                    return firstAddresses.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.Province + " " + x.StreetAddress + " " + x.HouseNumber, Value = x.Id.ToString() }).ToList();
            }
            return new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        }

        /// <summary>
        /// Makes a select list of companies
        /// </summary>
        /// <returns>SelectList of companies</returns>
        private async Task<List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>> Companies()
        {
            var companies = await _companyAppService.GetAll();
            if (companies.Any())
                return companies.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            return new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        }

        /// <summary>
        /// Makes a select list of PaymentTypes
        /// </summary>
        /// <returns>SelectList of PaymentTypes</returns>
        private async Task<List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>> PaymentTypes()
        {
            var paymentTypes = await _paymentTypeAppService.GetAll();
            if(paymentTypes.Any())
                return paymentTypes.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.TypeName, Value = x.Id.ToString() }).ToList();
            return new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        }

        /// <summary>
        /// Gets the next order number
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>int next order number</returns>
        private int GetNextOrderNumber(List<int> numbers)
        {
            if(!numbers.Any())
                return 1;
            return numbers.Max() + 1;
        }

        #endregion

        #endregion
    }
}
