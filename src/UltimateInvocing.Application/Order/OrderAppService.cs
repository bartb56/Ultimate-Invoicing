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

namespace UltimateInvocing.Order
{
    public class OrderAppService : UltimateInvocingAppServiceBase, IOrderAppService
    {
        IRepository<Models.Order, Guid> _repository;
        private readonly ICustomerAppService _customerAppService;
        private readonly ICompanyAppService _companyAppService;
        private readonly IPaymentTypeAppService _paymentTypeAppService;
        private readonly IAddressAppService _addressAppService;

        public OrderAppService(IRepository<Models.Order, Guid> repository,
            ICustomerAppService customerAppService,
            ICompanyAppService companyAppService,
            IPaymentTypeAppService paymentTypeAppService,
            IAddressAppService addressAppService)
        {
            _repository = repository;
            _customerAppService = customerAppService;
            _companyAppService = companyAppService;
            _paymentTypeAppService = paymentTypeAppService;
            _addressAppService = addressAppService;
        }

        public async Task Create(OrderCreateModel orderCreateModel)
        {
            var customer = await _customerAppService.GetById(orderCreateModel.CustomerId);
            var company = await _companyAppService.GetById(orderCreateModel.CompanyId);
            var paymentType = await _paymentTypeAppService.GetById(orderCreateModel.PaymentMethodId);
            var address = await _addressAppService.GetById(orderCreateModel.AddressId);
            if (paymentType == null || customer == null || company == null || address == null)
                throw new Exception("An error has occurred please try again.");

            OrderDto model = new OrderDto()
            {
                //Company section
                CompanyBTW = company.BTW,
                CompanyCity = company.City,
                CompanyCountryName = company.Country.Name,
                CompanyHouseNumber = company.HouseNumber,
                CompanyIBAN = company.IBAN,
                CompanyKVK = company.KVK,
                CompanyLogo = company.Logo,
                CompanyName = company.Name,
                CompanyPhoneNumber = company.PhoneNumber,
                CompanyId = company.Id,
                CompanyPostalCode = company.PostalCode,
                CompanyProvinceName = company.Province.Name,
                CompanyStreetAddress = company.StreetAddress,

                //Customer section
                CustomerCity = address.City,
                CustomerCompanyEmail = customer.CompanyEmail,
                CustomerCompanyName = customer.CompanyName,
                CustomerCompanyPhonenumber = company.PhoneNumber,
                CustomerCountryName = address.Country.Name,
                CustomerHouseNumber = address.HouseNumber,
                CustomerPhoneNumber = address.PhoneNumber,
                CustomerPostalCode = address.PostalCode,
                CustomerProvinceName = address.Province.Name,
                CustomerStreetAddress = address.StreetAddress,
                CustomerTaxable = address.Taxable,
                CustomerId = customer.Id,
                CustomerAddressId = orderCreateModel.AddressId,
                

                //Payment type section
                PaymentTypeName = paymentType.TypeName,
                PaymentTypeId = paymentType.Id
            };

            await _repository.InsertAsync(ObjectMapper.Map<Models.Order>(model));
            return;
        }

        public async Task Delete(Guid id)
        {
            await _repository.DeleteAsync(await _repository.GetAsync(id));
        }

        public async Task<OrderListModel> GetAll()
        {
            var orders = await _repository.GetAllListAsync();
            var model = new OrderListModel();
            model.orders = ObjectMapper.Map<List<OrderDto>>(orders);

            var customers = await _customerAppService.GetAll();
            var companies = await _companyAppService.GetAll();
            var paymentTypes = await _paymentTypeAppService.GetAll();
            if(customers.Any() || companies.Any() || paymentTypes.Any())
            {
                var addreses = await _addressAppService.GetAllByCustomerId(customers.First().Id);

                model.Customers = customers.Select(x => new SelectListItem { Text = x.CompanyName, Value = x.Id.ToString() }).ToList();
                model.Addresses = addreses.Select(x => new SelectListItem { Text = x.StreetAddress + " " + x.HouseNumber, Value = x.Id.ToString() }).ToList();
                model.Companies = companies.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                model.PaymentTypes = paymentTypes.Select(x => new SelectListItem { Text = x.TypeName, Value = x.Id.ToString() }).ToList();
            }
            return model;
        }

        public async Task<OrderDto> GetById(Guid id)
        {
            return ObjectMapper.Map<OrderDto>(await _repository.GetAsync(id));
        }

        public async Task Update(Guid orderId)
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
                order.CustomerCompanyEmail = customer.CompanyEmail;
                order.CustomerCompanyName = customer.CompanyName;
                order.CustomerCity = address.City;
            }

            await _repository.UpdateAsync(order);
            return;
        }

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
                order.CustomerCompanyEmail = customer.CompanyEmail;
                order.CustomerCompanyName = customer.CompanyName;
                order.CustomerCity = address.City;
            }

            await _repository.UpdateAsync(order);
            return;
        }

        /// <summary>
        /// Updates the company details
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
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
    }
}
