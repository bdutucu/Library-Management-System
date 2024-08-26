using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LibraryManagement.v5.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class v5DbContextFactory : IDesignTimeDbContextFactory<v5DbContext>
{
    public v5DbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        v5EfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<v5DbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new v5DbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../LibraryManagement.v5.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
