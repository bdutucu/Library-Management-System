using System.Threading.Tasks;

namespace LibraryManagement.v5.Data;

public interface Iv5DbSchemaMigrator
{
    Task MigrateAsync();
}
