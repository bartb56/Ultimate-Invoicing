using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace UltimateInvocing.Authorization
{
    public class UltimateInvocingAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_General_Settings, L("Pages_General_Settings"));
            context.CreatePermission(PermissionNames.Pages_Customers, L("Pages_Customers"));
            context.CreatePermission(PermissionNames.Pages_Products, L("Pages_Products"));
            context.CreatePermission(PermissionNames.Pages_Companies, L("Pages_Companies"));
            context.CreatePermission(PermissionNames.Pages_PaymentTypes, L("Pages_PaymentTypes"));
            context.CreatePermission(PermissionNames.Pages_Orders, L("Pages_Orders"));
            context.CreatePermission(PermissionNames.Pages_TaxGroups, L("Pages_TaxGroups"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, UltimateInvocingConsts.LocalizationSourceName);
        }
    }
}
