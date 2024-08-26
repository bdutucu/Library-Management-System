using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LibraryManagement.v5.Data;
using Volo.Abp.DependencyInjection;

namespace LibraryManagement.v5.EntityFrameworkCore;

public class EntityFrameworkCorev5DbSchemaMigrator
    : Iv5DbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCorev5DbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the v5DbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<v5DbContext>()
            .Database
            .MigrateAsync();
    }
}
