using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using UltimateInvocing.Company.Dto;

namespace UltimateInvocing.Web.Factories.Company
{
    public interface ICompanyFactory
    {
        Task Create(CompanyDto companyDto);
        Task<CompanyListModel> PrepareCompanyModel();
        Task<CompanyListModel> PrepareEditModal(Guid id);

        Task<string> SetLogo(IFormFile image);

        Task Edit(CompanyDto companyDto);
    }
}
