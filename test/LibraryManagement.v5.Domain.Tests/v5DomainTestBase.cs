using Volo.Abp.Modularity;

namespace LibraryManagement.v5;

/* Inherit from this class for your domain layer tests. */
public abstract class v5DomainTestBase<TStartupModule> : v5TestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
