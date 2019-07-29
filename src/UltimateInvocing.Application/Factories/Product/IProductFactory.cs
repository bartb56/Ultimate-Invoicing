using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Factories.Product.ViewModels;

namespace UltimateInvocing.Factories.Product
{
    public interface IProductFactory : IApplicationService
    {
        Task<ProductListModel> PrepareListModel();
        Task<EditProductViewModel> PrepareEditModel(Guid productId);
    }
}
