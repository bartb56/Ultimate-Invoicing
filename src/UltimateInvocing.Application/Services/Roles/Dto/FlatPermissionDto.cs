using Abp.Authorization;
using Abp.AutoMapper;

namespace UltimateInvocing.Roles.Dto
{
    [AutoMap(typeof(Permission))]
    public class FlatPermissionDto
    {
        public string Name { get; set; }
        
        public string DisplayName { get; set; }
        
        public string Description { get; set; }
    }
}