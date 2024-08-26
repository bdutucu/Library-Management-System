using LibraryManagement.v5.Localization;
using Volo.Abp.Application.Services;

namespace LibraryManagement.v5;

/* Inherit your application services from this class.
 */
public abstract class v5AppService : ApplicationService
{
    protected v5AppService()
    {
        LocalizationResource = typeof(v5Resource);
    }
}
