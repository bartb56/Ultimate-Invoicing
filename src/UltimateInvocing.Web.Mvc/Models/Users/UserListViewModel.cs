using System.Collections.Generic;
using UltimateInvocing.Roles.Dto;
using UltimateInvocing.Users.Dto;

namespace UltimateInvocing.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
