using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateInvocing.Services.Dashboard.DashboardModels
{
    public class Counters
    {
        public Counters(int customers, int products, int orders, int users)
        {
            Customers = customers;
            Orders = orders;
            Products = products;
            Users = users;
        }

        public int Customers { get; set; }
        public int Orders { get; set; }
        public int Products { get; set; }
        public int Users { get; set; }
    }
}
