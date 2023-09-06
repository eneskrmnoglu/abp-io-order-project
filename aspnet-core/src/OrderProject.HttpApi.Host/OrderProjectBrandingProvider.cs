using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace OrderProject;

[Dependency(ReplaceServices = true)]
public class OrderProjectBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "OrderProject";
}
