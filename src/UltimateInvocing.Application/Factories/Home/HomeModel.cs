using System;
using System.Collections.Generic;
using System.Text;
using UltimateInvocing.Factories.Order;
using UltimateInvocing.Services.Dashboard.DashboardModels;

namespace UltimateInvocing.Factories.Home
{
    public class HomeModel
    {
        public HomeModel(Counters counters, IList<Models.Order> recentOrders)
        {
            Counters = counters;
            RecentOrders = recentOrders;
        }

        public Counters Counters { get; set; }
        public IList<Models.Order> RecentOrders { get; set; }
        
    }
}
