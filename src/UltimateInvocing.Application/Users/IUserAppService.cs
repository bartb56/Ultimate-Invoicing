using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using UltimateInvocing.Roles.Dto;
using UltimateInvocing.Users.Dto;

namespace UltimateInvocing.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
