using System.Collections.Generic;
using UltimateInvocing.Roles.Dto;

namespace UltimateInvocing.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}