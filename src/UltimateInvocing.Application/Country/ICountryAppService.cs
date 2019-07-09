using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UltimateInvocing.Country.Dto;

namespace UltimateInvocing.Country
{
    public interface ICountryAppService : IApplicationService
    {

        Task<List<CountryDto>> GetAll();
        Task Create(CountryDto countryDto);
        Task DeleteCustom(Guid id);
        Task<CountryDto> GetById(Guid id);
        Task Update(CountryDto countryDto);
        IQueryable<Models.Country> GetCountries();
    }
}
