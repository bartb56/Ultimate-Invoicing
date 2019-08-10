using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Company.Dto;

namespace UltimateInvocing.Company
{
    public interface ICompanyAppService : IApplicationService
    {
        Task<List<CompanyDto>> GetAll();
        Task<List<CompanyDto>> GetAllByCountryId(Guid id);
        Task Create(CompanyDto countryDto);
        Task Delete(Guid id);
        Task<CompanyDto> GetById(Guid id);
        Task Update(CompanyDto countryDto);
    }
}
