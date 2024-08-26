using System.Threading.Tasks;
using LibraryManagement.v5.Localization;
using LibraryManagement.v5.Permissions;
using LibraryManagement.v5.MultiTenancy;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.Identity.Blazor;

namespace LibraryManagement.v5.Blazor.Menus;

public class v5MenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<v5Resource>();
        
        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                v5Menus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 1
            )
        );

        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 4;
    
        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        context.Menu.AddItem(
         new ApplicationMenuItem(
             "BooksStore",
             l["Menu:v5"],
             icon: "fa fa-book"
         ).AddItem(
             new ApplicationMenuItem(
                 "BooksStore.Books",
                 l["Menu:Books"],
                 url: "/books"
             ).RequirePermissions(v5Permissions.Books.Default) 
         )
        );

       // if (await context.IsGrantedAsync(v5Permissions.Authors.Default))
        {
            context.Menu.AddItem(new ApplicationMenuItem(
                "BooksStore.Authors",
                l["Menu:Authors"],
                url: "/authors"
            ));
        }


        return Task.CompletedTask;
    }
}
