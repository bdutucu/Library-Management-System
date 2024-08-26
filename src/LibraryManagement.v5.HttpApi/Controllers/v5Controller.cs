using LibraryManagement.v5.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LibraryManagement.v5.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class v5Controller : AbpControllerBase
{
    protected v5Controller()
    {
        LocalizationResource = typeof(v5Resource);
    }
}
