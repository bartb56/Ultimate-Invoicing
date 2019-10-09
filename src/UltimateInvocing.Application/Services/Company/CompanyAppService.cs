using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Authorization;
using UltimateInvocing.Company.Dto;
using UltimateInvocing.Web.Factories.Company;

namespace UltimateInvocing.Company
{
    [AbpAuthorize]
    [AbpAuthorize(PermissionNames.Pages_Companies)]
    public class CompanyAppService : UltimateInvocingAppServiceBase, ICompanyAppService
    {
        private readonly IRepository<Models.Company, Guid> _repository;

        public CompanyAppService(IRepository<Models.Company, Guid> repository)
        {
            _repository = repository;
 
        }

        public async Task Create(CompanyDto companyDto)
        { 
            var company = ObjectMapper.Map<Models.Company>(companyDto);
            await _repository.InsertAsync(company);
            return;
        }

        public async Task Delete(Guid id)
        {
            var company = _repository.Get(id);
            if (company != null)
            {
                await _repository.DeleteAsync(company);
            }
            return;
        }

        public async Task<List<CompanyDto>> GetAll()
        {
            return ObjectMapper.Map<List<CompanyDto>>(await _repository.GetAll().Include(x => x.Country).ToListAsync());
        }

        public async Task<List<CompanyDto>> GetAllByCountryId(Guid id)
        {
            return ObjectMapper.Map<List<CompanyDto>>(await _repository.GetAll().Where(x => x.CountryId == id).ToListAsync());
        }

        public async Task<CompanyDto> GetById(Guid id)
        {
            return ObjectMapper.Map<CompanyDto>(await _repository.GetAll().Include(x => x.Country).Include(x => x.Province).FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task Update(CompanyDto companyDto)
        {
            var company = ObjectMapper.Map<Models.Company>(companyDto);
            await _repository.UpdateAsync(company);
            return;
        }
    }
}
