using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Services.Dashboard.DashboardModels;

namespace UltimateInvocing.Services.Dashboard
{
    public interface IDashboardAppService : IApplicationService
    {
        Task<Counters> GetCounters();
        Task<IList<Models.Order>> GetMostRecentOrders();
        Task<string> GetOrderGraph();
        Task<string> GetBestSellers();
    }
}
