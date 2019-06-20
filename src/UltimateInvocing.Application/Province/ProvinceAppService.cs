using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Authorization;
using UltimateInvocing.Province.Dto;

namespace UltimateInvocing.Province
{
    [AbpAuthorize(PermissionNames.Pages_General_Settings)]
    public class ProvinceAppService : UltimateInvocingAppServiceBase, IProvinceAppService
    {
        private readonly IRepository<Models.Province, Guid> _repository;

        public ProvinceAppService(IRepository<Models.Province, Guid> repository)
        {
            _repository = repository;
        }

        public async Task Create(ProvinceDto provinceDto)
        {
            var province = ObjectMapper.Map<Models.Province>(provinceDto);
            await _repository.InsertAsync(province);
            return;
        }

        public async Task Delete(Guid id)
        {
            var province = _repository.Get(id);
            if (province != null)
            {
                await _repository.DeleteAsync(province);
            }
            return;
        }

        public async Task<List<ProvinceDto>> GetAll()
        {
            return ObjectMapper.Map<List<ProvinceDto>>(await _repository.GetAll().Include(x => x.Country).ToListAsync());
        }

        public async Task<List<ProvinceDto>> GetAllByCountryId(Guid id)
        {
            return ObjectMapper.Map<List<ProvinceDto>>(await _repository.GetAll().Where(x => x.CountryId == id).ToListAsync());
        }

        public async Task<ProvinceDto> GetById(Guid id)
        {
            return ObjectMapper.Map<ProvinceDto>(await _repository.GetAsync(id));
        }

        public async Task Update(ProvinceDto provinceDto)
        {
            var province = ObjectMapper.Map<Models.Province>(provinceDto);
            await _repository.UpdateAsync(province);
            return;
        }
    }
}
