using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace UltimateInvocing.Web.Views
{
    public abstract class UltimateInvocingRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected UltimateInvocingRazorPage()
        {
            LocalizationSourceName = UltimateInvocingConsts.LocalizationSourceName;
        }
    }
}
