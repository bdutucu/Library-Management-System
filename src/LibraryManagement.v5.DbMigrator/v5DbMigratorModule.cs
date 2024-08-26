using LibraryManagement.v5.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace LibraryManagement.v5.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(v5EntityFrameworkCoreModule),
    typeof(v5ApplicationContractsModule)
)]
public class v5DbMigratorModule : AbpModule
{
}
