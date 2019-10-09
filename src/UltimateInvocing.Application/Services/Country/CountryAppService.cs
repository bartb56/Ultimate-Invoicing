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
    [AbpAuthorize]
    [AbpAuthorize(PermissionNames.Pages_General_Settings)]
    public class CountryAppService : UltimateInvocingAppServiceBase, ICountryAppService
    {
        private readonly IRepository<Models.Country, Guid> _repository;

        public CountryAppService(IRepository<Models.Country, Guid> repository)
        {
            _repository = repository;
        }

        public async Task Create(CountryDto countryDto)
        {
            await _repository.InsertAsync(ObjectMapper.Map<Models.Country>(countryDto));
            return;
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
            var countries = await _repository.GetAllListAsync();
            return ObjectMapper.Map<List<CountryDto>>(countries.OrderBy(x => x.DisplayOrder));
        }

        public async Task<CountryDto> GetById(Guid id)
        {
            return ObjectMapper.Map<CountryDto>(await _repository.GetAsync(id));
        }

        public IQueryable<Models.Country> GetCountries()
        {
            return _repository.GetAll();
        }

        public async Task Update(CountryDto countryDto)
        {
            var country = ObjectMapper.Map<Models.Country>(countryDto);
            await _repository.UpdateAsync(country);
            return;
        }
    }
}
