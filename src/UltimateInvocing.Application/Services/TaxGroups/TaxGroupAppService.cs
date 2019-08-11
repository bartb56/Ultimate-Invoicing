using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Services.TaxGroups.Dto;

namespace UltimateInvocing.Services.TaxGroups
{
    public class TaxGroupAppService : UltimateInvocingAppServiceBase, ITaxGroupAppService
    {
        private readonly IRepository<Models.TaxGroup, Guid> _repository;

        public TaxGroupAppService(IRepository<Models.TaxGroup, Guid> repository)
        {
            _repository = repository;
        }

        public async Task Create(TaxGroupDto taxGroupDto)
        {
            var taxGroup = ObjectMapper.Map<Models.TaxGroup>(taxGroupDto);
            await _repository.InsertAsync(taxGroup);
            return;
        }

        public async Task Delete(Guid id)
        {
            var taxGroup = _repository.Get(id);
            if (taxGroup != null)
            {
                await _repository.DeleteAsync(taxGroup);
            }
            return;
        }

        public async Task<List<TaxGroupDto>> GetAll()
        {
            var taxGroups = await _repository.GetAllListAsync();
            return ObjectMapper.Map<List<TaxGroupDto>>(taxGroups.OrderBy(x => x.DisplayOrder));
        }

        public async Task<TaxGroupDto> GetById(Guid id)
        {
            var taxGroup = await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            if (taxGroup == null)
                return new TaxGroupDto();

            return ObjectMapper.Map<TaxGroupDto>(await _repository.GetAsync(id));
        }

        public async Task Update(TaxGroupDto taxGroupDto)
        {
            var taxGroup = ObjectMapper.Map<Models.TaxGroup>(taxGroupDto);
            await _repository.UpdateAsync(taxGroup);
            return;
        }
    }
}
