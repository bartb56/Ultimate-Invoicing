using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace UltimateInvocing.Controllers
{
    public abstract class UltimateInvocingControllerBase: AbpController
    {
        protected UltimateInvocingControllerBase()
        {
            LocalizationSourceName = UltimateInvocingConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
