using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Province.Dto;

namespace UltimateInvocing.Province
{
    public interface IProvinceAppService : IApplicationService
    {
        Task<List<ProvinceDto>> GetAll();
        Task<List<ProvinceDto>> GetAllByCountryId(Guid id);
        Task Create(ProvinceDto countryDto);
        Task Delete(Guid id);
        Task<ProvinceDto> GetById(Guid id);
        Task Update(ProvinceDto countryDto);
    }
}
