using LibraryManagement.v5.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace LibraryManagement.v5.Permissions;

public class v5PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(v5Permissions.GroupName);

        var booksPermission = myGroup.AddPermission(v5Permissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(v5Permissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(v5Permissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(v5Permissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(v5Permissions.MyPermission1, L("Permission:MyPermission1"));


        var authorsPermission = myGroup.AddPermission(v5Permissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(v5Permissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(v5Permissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(v5Permissions.Authors.Delete, L("Permission:Authors.Delete"));


        var shelvesPermission = myGroup.AddPermission(v5Permissions.Shelves.Default, L("Permission:Shelves"));
        shelvesPermission.AddChild(v5Permissions.Shelves.Create, L("Permission:Shelves.Create"));
        shelvesPermission.AddChild(v5Permissions.Shelves.Edit, L("Permission:Shelves.Edit"));
        shelvesPermission.AddChild(v5Permissions.Shelves.Delete, L("Permission:Shelves.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<v5Resource>(name);
    }
}
