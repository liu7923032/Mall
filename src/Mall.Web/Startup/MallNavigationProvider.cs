using Abp.Application.Navigation;
using Abp.Localization;

namespace Mall.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class MallNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                            PageNames.Mall,
                            L("Mall"),
                            url: "/Home/Index",
                            icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                            PageNames.Cart,
                            L("Cart"),
                            url: "Cart/Index",
                            icon: "fa fa-info"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                            PageNames.Category,
                            L("Order"),
                            url: "/Order/Index",
                            icon: ""
                        )
                ).AddItem(
                    new MenuItemDefinition(
                            PageNames.Approve,
                            L("Manage"),
                            url: ""
                        )
                        .AddItem(new MenuItemDefinition(
                             PageNames.Category,
                             L("Category"),
                             url: "/Category/Index"
                            ))
                        .AddItem(new MenuItemDefinition(
                             PageNames.Category,
                             L("Product"),
                             url: "/Category/Product"
                        ))
                        .AddItem(new MenuItemDefinition(
                             PageNames.Approve,
                             L("Approve"),
                             url: "/Order/Approve"
                        ))

                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MallConsts.LocalizationSourceName);
        }
    }
}
