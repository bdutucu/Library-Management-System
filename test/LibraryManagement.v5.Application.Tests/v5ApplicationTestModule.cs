using Volo.Abp.Modularity;

namespace LibraryManagement.v5;

[DependsOn(
    typeof(v5ApplicationModule),
    typeof(v5DomainTestModule)
)]
public class v5ApplicationTestModule : AbpModule
{

}
