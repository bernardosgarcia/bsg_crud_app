using bsg_crud_app.Context;
using bsg_crud_app.Migrations;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;

namespace bsg_crud_app.Config;

/// <summary>
/// Program.cs extension for database and context configurations
/// </summary>
public static class DbContextConfig
{
    /// <summary>
    /// Set API database configurations
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void ConfigureDbContext(this IServiceCollection services, ConfigurationManager configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<CrudAppContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddPostgres()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(InitialMigration).Assembly).For.Migrations());
    }
}