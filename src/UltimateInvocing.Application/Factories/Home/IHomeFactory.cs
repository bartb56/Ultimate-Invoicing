using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UltimateInvocing.Factories.Home
{
    public interface IHomeFactory
    {
        Task<HomeModel> PrepareModel();
    }
}
