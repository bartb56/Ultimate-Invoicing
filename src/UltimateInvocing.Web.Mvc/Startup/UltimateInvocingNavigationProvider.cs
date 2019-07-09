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
                    )
                    ).AddItem(
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
                ).AddItem( // Menu items below is just for demonstration!
                    new MenuItemDefinition(
                        "MultiLevelMenu",
                        L("MultiLevelMenu"),
                        icon: "menu"
                    ).AddItem(
                        new MenuItemDefinition(
                            "AspNetBoilerplate",
                            new FixedLocalizableString("ASP.NET Boilerplate")
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetBoilerplateHome",
                                new FixedLocalizableString("Home"),
                                url: "https://aspnetboilerplate.com?ref=abptmpl"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetBoilerplateTemplates",
                                new FixedLocalizableString("Templates"),
                                url: "https://aspnetboilerplate.com/Templates?ref=abptmpl"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetBoilerplateSamples",
                                new FixedLocalizableString("Samples"),
                                url: "https://aspnetboilerplate.com/Samples?ref=abptmpl"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetBoilerplateDocuments",
                                new FixedLocalizableString("Documents"),
                                url: "https://aspnetboilerplate.com/Pages/Documents?ref=abptmpl"
                            )
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "AspNetZero",
                            new FixedLocalizableString("ASP.NET Zero")
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroHome",
                                new FixedLocalizableString("Home"),
                                url: "https://aspnetzero.com?ref=abptmpl"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroDescription",
                                new FixedLocalizableString("Description"),
                                url: "https://aspnetzero.com/?ref=abptmpl#description"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroFeatures",
                                new FixedLocalizableString("Features"),
                                url: "https://aspnetzero.com/?ref=abptmpl#features"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroPricing",
                                new FixedLocalizableString("Pricing"),
                                url: "https://aspnetzero.com/?ref=abptmpl#pricing"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroFaq",
                                new FixedLocalizableString("Faq"),
                                url: "https://aspnetzero.com/Faq?ref=abptmpl"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroDocuments",
                                new FixedLocalizableString("Documents"),
                                url: "https://aspnetzero.com/Documents?ref=abptmpl"
                            )
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
