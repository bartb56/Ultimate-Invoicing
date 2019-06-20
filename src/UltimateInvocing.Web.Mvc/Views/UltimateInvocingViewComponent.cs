using Abp.AspNetCore.Mvc.ViewComponents;

namespace UltimateInvocing.Web.Views
{
    public abstract class UltimateInvocingViewComponent : AbpViewComponent
    {
        protected UltimateInvocingViewComponent()
        {
            LocalizationSourceName = UltimateInvocingConsts.LocalizationSourceName;
        }
    }
}
