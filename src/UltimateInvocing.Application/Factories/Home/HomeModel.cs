using System;
using System.Collections.Generic;
using System.Text;
using UltimateInvocing.Factories.Order;

namespace UltimateInvocing.Factories.Home
{
    public class HomeModel
    {
        public int Customers { get; set; }
        public int Users { get; set; }
        public int Products { get; set; }
        public int Orders { get; set; }

        public OrderListModel RecentOrders { get; set; }
        
    }
}
