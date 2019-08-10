using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimateInvocing.Services.TaxGroups.Dto;

namespace UltimateInvocing.Services.TaxGroups
{
    public interface ITaxGroupAppService : IApplicationService
    {
        Task<List<TaxGroupDto>> GetAll();
        Task Create(TaxGroupDto taxGroupDto);
        Task Delete(Guid id);
        Task<TaxGroupDto> GetById(Guid id);
        Task Update(TaxGroupDto taxGroupDto);
    }
}
