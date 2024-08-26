using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace LibraryManagement.v5.Data;

/* This is used if database provider does't define
 * Iv5DbSchemaMigrator implementation.
 */
public class Nullv5DbSchemaMigrator : Iv5DbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
