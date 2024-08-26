using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace LibraryManagement.v5.Blazor;

[Dependency(ReplaceServices = true)]
public class v5BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "v5";
}
