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

        public async Task<Guid> Create(OrderCreateModel orderCreateModel)
        {
            var customer = await _customerAppService.GetById(orderCreateModel.CustomerId);
            var company = await _companyAppService.GetById(orderCreateModel.CompanyId);
            var paymentType = await _paymentTypeAppService.GetById(orderCreateModel.PaymentMethodId);
            var address = await _addressAppService.GetById(orderCreateModel.AddressId);
            if (paymentType == null || customer == null || company == null || address == null)
                throw new Exception("An error has occurred please try again.");

            OrderDto model = new OrderDto()
            {
                //Order section
                Number = orderCreateModel.Number,

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

            return await _repository.InsertAndGetIdAsync(ObjectMapper.Map<Models.Order>(model));
        }

        public async Task Delete(Guid id)
        {
            await _repository.DeleteAsync(await _repository.GetAll().Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<OrderListModel> GetAll()
        {
            var orders = await _repository.GetAll().Include(x => x.OrderItems).ToListAsync();
            var model = new OrderListModel();
            model.orders = ObjectMapper.Map<List<OrderDto>>(orders.OrderByDescending(x => x.OrderCreationtTime).ToList());

            var numbers = model.orders.Select(x => x.Number);
            if (numbers.Any())
                model.NewOrderNumber = numbers.Max() + 1;
            else
                model.NewOrderNumber = 1;
            var customers = await _customerAppService.GetAll();
            var companies = await _companyAppService.GetAll();
            var paymentTypes = await _paymentTypeAppService.GetAll();
            if(customers.Any())
                model.Customers = customers.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.CompanyName, Value = x.Id.ToString() }).ToList();
            if (companies.Any())
            {
                var addreses = await _addressAppService.GetAllByCustomerId(customers.First().Id);
                if (addreses.Any())
                    model.Addresses = addreses.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.StreetAddress + " " + x.HouseNumber, Value = x.Id.ToString() }).ToList();
            }
            if(companies.Any())
                model.Companies = companies.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            model.PaymentTypes = paymentTypes.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.TypeName, Value = x.Id.ToString() }).ToList();
            return model;
        }

        public async Task<OrderDto> GetById(Guid id)
        {
            return ObjectMapper.Map<OrderDto>(await _repository.GetAll().Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == id));
        }

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
            order.CustomerCompanyEmail = customer.CompanyEmail;
            order.CustomerCompanyName = customer.CompanyName;
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

        public async Task<OrderListModel> Get(int amount)
        {
            if (amount == 0)
                throw new Exception("Amount can not be 0");

            var orders = await _repository.GetAll().OrderByDescending(x => x.OrderCreationtTime).ToListAsync();
            orders = orders.Take(5).ToList();

            var model = new OrderListModel();
            model.orders = ObjectMapper.Map<List<OrderDto>>(orders);

            var numbers = model.orders.Select(x => x.Number);
            if (numbers.Any())
                model.NewOrderNumber = numbers.Max() + 1;
            else
                model.NewOrderNumber = 1;
            var customers = await _customerAppService.GetAll();
            var companies = await _companyAppService.GetAll();
            var paymentTypes = await _paymentTypeAppService.GetAll();
            if (customers.Any())
                model.Customers = customers.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.CompanyName, Value = x.Id.ToString() }).ToList();
            if (companies.Any())
            {
                var addreses = await _addressAppService.GetAllByCustomerId(customers.First().Id);
                if (addreses.Any())
                    model.Addresses = addreses.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.StreetAddress + " " + x.HouseNumber, Value = x.Id.ToString() }).ToList();
            }
            if (companies.Any())
                model.Companies = companies.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            model.PaymentTypes = paymentTypes.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.TypeName, Value = x.Id.ToString() }).ToList();
            return model;
        }

        public async Task<string> GetWeeklyBestSellers()
        {
            var firstDate = DateTime.Now.AddDays(-7);

            var orders = await _repository.GetAll().Include(x => x.OrderItems).Where(x => x.OrderCreationtTime >= firstDate).ToListAsync();

            var orderItemsTotal = new List<Models.OrderItem>();
            foreach(Models.Order order in orders)
            {
                orderItemsTotal.AddRange(order.OrderItems);
            }

            var topOrderItems = new List<BestSellers>();


            var options = new List<BestSellers>();
            foreach (var orderItem in orderItemsTotal)
            {
                var option = options.FirstOrDefault(x => x.label == orderItem.Name);
                if (option == null)
                {
                    options.Add(new BestSellers { label = orderItem.Name, value = orderItem.Quantity });
                }
                else
                {
                    option.value += orderItem.Quantity;
                }
            }
            topOrderItems = options.OrderByDescending(x => x.value).Take(5).ToList();

            var totalProducts = 0;
            foreach(var bestSeller in topOrderItems)
            {
                totalProducts += bestSeller.value;
            }

            float percentPerItem = 100 / totalProducts;
            foreach (var bestSeller in topOrderItems)
            {
                bestSeller.value = bestSeller.value * (int)percentPerItem;
            }

            return JsonConvert.SerializeObject(topOrderItems);
        }

        public async Task<string> GetLastWeekOrderCount()
        {
            List<Graph> data = new List<Graph>();

            var firstDate = DateTime.Now.AddDays(-6);
            for(int daysPassed = 0; daysPassed < 7; daysPassed++)
            {
                var graphSequence = new Graph();
                var newDate = firstDate.AddDays(daysPassed);
                var counter = await _repository.GetAll().Where(x => x.OrderCreationtTime.Date == newDate.Date).ToListAsync();
                graphSequence.Value = 0;
                if (counter != null)
                    graphSequence.Value = counter.Count();

                graphSequence.Name = L(newDate.Date.DayOfWeek.ToString());
                data.Add(graphSequence);
            }
            return JsonConvert.SerializeObject(data);
        }

        public class Graph
        {
            public int Value { get; set; }

            public string Name { get; set; }
        }

        public class BestSellers
        {
            public string label;
            public int value;
        }
    }
}
