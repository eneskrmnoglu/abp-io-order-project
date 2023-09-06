using OrderProject.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace OrderProject.Permissions;

public class OrderProjectPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var orderProjectGroup = context.AddGroup(OrderProjectPermissions.GroupName, L("Permission:OrderProject"));

        var customersPermission = orderProjectGroup.AddPermission(OrderProjectPermissions.Customers.Default, L("Permission:Customers"));
        customersPermission.AddChild(OrderProjectPermissions.Customers.Create, L("Permission:Customers.Create"));
        customersPermission.AddChild(OrderProjectPermissions.Customers.Edit, L("Permission:Customers.Edit"));
        customersPermission.AddChild(OrderProjectPermissions.Customers.Delete, L("Permission:Customers.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(OrderProjectPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<OrderProjectResource>(name);
    }
}
