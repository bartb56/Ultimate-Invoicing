using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Authorization.Users;
using UltimateInvocing.Order;
using UltimateInvocing.Services.Dashboard;

namespace UltimateInvocing.Factories.Home
{
    public class HomeFactory : IHomeFactory
    {
        private readonly IDashboardAppService _dashboardAppService;


        public HomeFactory(IDashboardAppService dashboardAppService)
        {
            _dashboardAppService = dashboardAppService;
        }

        public async Task<HomeModel> PrepareModel()
        {
            var counters = await _dashboardAppService.GetCounters();
            var mostRecentOrders = await _dashboardAppService.GetMostRecentOrders();
            return new HomeModel(counters, mostRecentOrders);
        }
    }
}
