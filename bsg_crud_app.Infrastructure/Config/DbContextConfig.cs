using bsg_crud_app.Context;
using bsg_crud_app.Repositories.Implementations;
using bsg_crud_app.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bsg_crud_app.Infrastructure.Config;

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
    public static void AddInfrastructureConfigs(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<CrudAppContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IProductRepository, ProductRepository>();
    }
}