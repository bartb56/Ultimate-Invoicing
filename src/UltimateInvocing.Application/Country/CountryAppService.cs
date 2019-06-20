using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UltimateInvocing.Authorization;
using UltimateInvocing.Country.Dto;
using UltimateInvocing.Models;

namespace UltimateInvocing.Country
{
    [AbpAuthorize(PermissionNames.Pages_General_Settings)]
    public class CountryAppService : AsyncCrudAppService<Models.Country, CountryDto, Guid>, ICountryAppService
    {
        private readonly IRepository<Models.Country, Guid> _repository;

        public CountryAppService(IRepository<Models.Country, Guid> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task DeleteCustom(Guid id)
        {
            var country = _repository.Get(id);
            if(country != null)
            {
               await _repository.DeleteAsync(country);
            }
            return;
        }

        public async Task<List<CountryDto>> GetAll()
        {
            return ObjectMapper.Map<List<CountryDto>>(await _repository.GetAllListAsync());
        }

        public async Task<CountryDto> GetById(Guid id)
        {
            return ObjectMapper.Map<CountryDto>(await _repository.GetAsync(id));
        }

        public IQueryable<Models.Country> GetCountries()
        {
            return _repository.GetAll();
        }
    }
}
