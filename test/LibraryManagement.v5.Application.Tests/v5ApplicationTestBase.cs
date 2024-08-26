using Volo.Abp.Modularity;

namespace LibraryManagement.v5;

public abstract class v5ApplicationTestBase<TStartupModule> : v5TestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
