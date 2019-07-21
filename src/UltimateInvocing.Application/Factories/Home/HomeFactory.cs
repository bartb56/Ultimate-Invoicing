using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Authorization.Users;

namespace UltimateInvocing.Factories.Home
{
    public class HomeFactory : IHomeFactory
    {
        private readonly IRepository<Models.Customer, Guid> _repository;
        private readonly IRepository<Models.Product, Guid> _productRepository;
        private readonly IRepository<Models.Order, Guid> _orderRepository;
        IRepository<User, long> _userRepository;

        public HomeFactory(IRepository<Models.Customer, Guid> repository,
            IRepository<User, long> userRepository,
            IRepository<Models.Product, Guid> productRepository,
            IRepository<Models.Order, Guid> orderRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public async Task<HomeModel> PrepareModel()
        {
            var model = new HomeModel()
            {
                Customers = await _repository.CountAsync(),
                Users = await _userRepository.CountAsync(),
                Products = await _productRepository.CountAsync(),
                Orders = await _orderRepository.CountAsync()
            };
            return model;
        }
    }
}
