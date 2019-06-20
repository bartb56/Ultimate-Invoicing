using System.Collections.Generic;
using UltimateInvocing.Roles.Dto;

namespace UltimateInvocing.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleListDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
