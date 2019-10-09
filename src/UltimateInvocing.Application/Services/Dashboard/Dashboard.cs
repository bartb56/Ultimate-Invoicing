using Abp.Authorization;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Authorization.Users;
using UltimateInvocing.Models;
using System.Linq;
using UltimateInvocing.Services.Dashboard.DashboardModels;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using UltimateInvocing.Services.Order.Dto;
using Newtonsoft.Json;

namespace UltimateInvocing.Services.Dashboard
{
    [AbpAuthorize]
    public class DashboardAppService : UltimateInvocingAppServiceBase, IDashboardAppService
    {
        #region Fields
        private readonly IRepository<Models.Customer, Guid> _customerRepository;
        private readonly IRepository<Models.Order, Guid> _orderRepository;
        private readonly IRepository<Models.Product, Guid> _productRepository;
        private readonly IRepository<User, long> _userRepository;


        #endregion

        #region Constructor
        public DashboardAppService(IRepository<Customer, Guid> customerRepository, IRepository<Models.Order, Guid> orderRepository, IRepository<Models.Product, Guid> productRepository, IRepository<User, long> userRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }
        #endregion

        #region Methods

        #region RecentOrders

        public async Task<IList<Models.Order>> GetMostRecentOrders()
        {
            var amountOfOrders = await _orderRepository.CountAsync();
            if (amountOfOrders < 6)
                return await _orderRepository.GetAllListAsync();

            return await _orderRepository.GetAll().Take(5).ToListAsync();

        }

        #endregion

        #region Counters

        public async Task<Counters> GetCounters()
        {
            var customers = await CountCustomer();
            var products = await CountProducts();
            var orders = await CountOrders();
            var users = await CountUsers();

            return new Counters(customers, products, orders, users);
        }

        protected async Task<int> CountCustomer()
        {
            return await _customerRepository.CountAsync();
        }

        protected async Task<int> CountProducts()
        {
            return await _productRepository.CountAsync();
        }

        protected async Task<int> CountOrders()
        {
            return await _orderRepository.CountAsync();
        }

        protected async Task<int> CountUsers()
        {
            return await _userRepository.CountAsync();
        }

        #endregion

        #region Order Graph && Best solled products

        public async Task<string> GetOrderGraph()
        {
            List<Graph> data = new List<Graph>();

            var date = DateTime.Now.AddDays(-6);

            for (int daysPassed = 0; daysPassed < 7; daysPassed++)
            {
                var graphSequence = new Graph();
                var counter = await _orderRepository.GetAll().Where(x => x.OrderCreationtTime.Date == date.Date.AddDays(daysPassed)).CountAsync();

                graphSequence.Value = counter;
                graphSequence.Name = L(date.AddDays(daysPassed).Date.DayOfWeek.ToString());

                data.Add(graphSequence);
            }
            return JsonConvert.SerializeObject(data);
        }

        protected async Task<IList<Models.Order>> GetLastWeeksOrders(bool includeOrderItems = false)
        {
            var date = DateTime.Now.AddDays(-6);
            var orders = new List<Models.Order>();
            if(includeOrderItems)
                orders = await _orderRepository.GetAll().Include(x => x.OrderItems).Where(x => x.OrderCreationtTime >= date && x.OrderItems.Any()).ToListAsync();
            else
                orders = await _orderRepository.GetAll().Where(x => x.OrderCreationtTime >= date).ToListAsync();
            return orders;
        }

        public async Task<string> GetBestSellers()
        {

            var orders = await GetLastWeeksOrders(true);
            if (!orders.Any())
                return "";

            var options = new List<BestSellers>();
            foreach (var order in orders)
            {
                foreach(var orderItem in order.OrderItems)
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
            }
            var topOrderItems = options.OrderByDescending(x => x.value).Take(5).ToList();

            var totalProducts = 0;
            foreach (var bestSeller in topOrderItems)
            {
                totalProducts += bestSeller.value;
            }

            if (totalProducts == 0)
                return "{}";

            decimal percentPerItem = (decimal)100 / totalProducts;
            foreach (var bestSeller in topOrderItems)
            {
                decimal percentage = bestSeller.value * (decimal)percentPerItem;
                bestSeller.value = Decimal.ToInt32(percentage);
            }

            return JsonConvert.SerializeObject(topOrderItems);
        }
        

        #endregion

        #endregion
    }
}
