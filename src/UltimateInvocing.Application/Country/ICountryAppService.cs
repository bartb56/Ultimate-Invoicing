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
    public interface ICountryAppService : IAsyncCrudAppService<CountryDto, Guid>
    {

        Task<List<CountryDto>> GetAll();

        Task DeleteCustom(Guid id);
        Task<CountryDto> GetById(Guid id);

        IQueryable<Models.Country> GetCountries();
    }
}
