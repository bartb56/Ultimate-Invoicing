using Abp.Application.Navigation;
using Abp.Localization;
using UltimateInvocing.Authorization;

namespace UltimateInvocing.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class UltimateInvocingNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Order,
                        L("Orders"),
                        url: "Orders",
                        icon: "shopping_basket",
                        requiredPermissionName: PermissionNames.Pages_Orders
                        )
                    ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Product,
                        L("Products"),
                        url: "Products",
                        icon: "local_grocery_store",
                        requiredPermissionName: PermissionNames.Pages_Products
                        )
                    )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Customers,
                        L("Customers"),
                        url: "Customers",
                        icon: "people",
                        requiredPermissionName: PermissionNames.Pages_Customers
                        )
                    )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Company,
                        L("Companies"),
                        url: "Companies",
                        icon: "business",
                        requiredPermissionName: PermissionNames.Pages_Companies
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                     "General.Settings",
                     L("General.Settings"),
                     icon: "menu",
                     requiredPermissionName: PermissionNames.Pages_General_Settings
                    )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Countries,
                        L("Countries"),
                        url: "Countries"
                    )
                    )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Provinces,
                        L("Provinces"),
                        url: "Provinces"
                    )
                    ).AddItem(
                    new MenuItemDefinition(
                        PageNames.PaymentType,
                        L("PaymentTypes"),
                        url: "Settings/PaymentTypes"
                    )).AddItem(
                    new MenuItemDefinition(
                        PageNames.TaxGroups,
                        L("TaxGroups"),
                        url: "Settings/TaxGroups",
                        requiredPermissionName: PermissionNames.Pages_TaxGroups
                    )).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        requiredPermissionName: PermissionNames.Pages_Users
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        requiredPermissionName: PermissionNames.Pages_Roles
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.EmailTemplates,
                        L("Emails"),
                        url: "EmailTemplates",
                        requiredPermissionName: PermissionNames.Pages_Emails
                    )
                )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, UltimateInvocingConsts.LocalizationSourceName);
        }
    }
}
