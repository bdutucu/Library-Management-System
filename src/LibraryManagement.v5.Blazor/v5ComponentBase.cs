using LibraryManagement.v5.Localization;
using Volo.Abp.AspNetCore.Components;

namespace LibraryManagement.v5.Blazor;

public abstract class v5ComponentBase : AbpComponentBase
{
    protected v5ComponentBase()
    {
        LocalizationResource = typeof(v5Resource);
    }
}
