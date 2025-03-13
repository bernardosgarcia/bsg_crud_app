using bsg_crud_app.Application.Services.Implementations;
using bsg_crud_app.Application.Services.Interfaces;
using bsg_crud_app.Infrastructure.Config;
using bsg_crud_app.Repositories.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bsg_crud_app.Application.Config;

/// <summary>
/// Program.cs extension for configure life cycle injection dependencies
/// </summary>
public static class DependenciesConfig
{
    /// <summary>
    /// Configure infrastructure and application services
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructureConfigs(configuration);
        services.AddDependenciesLifeCycle();
    }

    /// <summary>
    /// Configure life cycle interfaces and implementations
    /// </summary>
    /// <param name="services"></param>
    public static void AddDependenciesLifeCycle(this IServiceCollection services)
    {
        services
            .AddScoped<IProductService, ProductService>();
    }
}