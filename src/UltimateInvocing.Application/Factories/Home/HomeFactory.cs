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
        IRepository<User, long> _userRepository;

        public HomeFactory(IRepository<Models.Customer, Guid> repository,
            IRepository<User, long> userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }
        public async Task<HomeModel> PrepareModel()
        {
            var model = new HomeModel()
            {
                Customers = await _repository.CountAsync(),
                Users = await _userRepository.CountAsync()
            };
            return model;
        }
    }
}
