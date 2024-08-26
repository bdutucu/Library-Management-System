using Volo.Abp.Modularity;

namespace LibraryManagement.v5;

[DependsOn(
    typeof(v5DomainModule),
    typeof(v5TestBaseModule)
)]
public class v5DomainTestModule : AbpModule
{

}
