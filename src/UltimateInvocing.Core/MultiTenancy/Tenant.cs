using Abp.MultiTenancy;
using UltimateInvocing.Authorization.Users;

namespace UltimateInvocing.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
