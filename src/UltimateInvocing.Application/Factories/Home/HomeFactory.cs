using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Authorization.Users;
using UltimateInvocing.Order;

namespace UltimateInvocing.Factories.Home
{
    public class HomeFactory : IHomeFactory
    {
        private readonly IRepository<Models.Customer, Guid> _repository;
        private readonly IRepository<Models.Product, Guid> _productRepository;

        private readonly IOrderAppService _orderAppService;

        IRepository<User, long> _userRepository;

        public HomeFactory(IRepository<Models.Customer, Guid> repository,
            IRepository<User, long> userRepository,
            IRepository<Models.Product, Guid> productRepository,
            IOrderAppService orderAppService
            )
        {
            _repository = repository;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _orderAppService = orderAppService;
        }
        public async Task<HomeModel> PrepareModel()
        {
            var orders = await _orderAppService.GetAll();
            var recentOrders = await _orderAppService.GetLastOrders(5);

            var model = new HomeModel()
            {
                Customers = await _repository.CountAsync(),
                Users = await _userRepository.CountAsync(),
                Products = await _productRepository.CountAsync(),
            };

            model.Orders = 0;
            if (orders.orders.Any())
                model.Orders = orders.orders.Count();

            model.RecentOrders = new Order.OrderListModel();
            if (recentOrders.orders.Any())
                model.RecentOrders.orders = recentOrders.orders;

            return model;
        }
    }
}
