using bsg_crud_app.Repositories.Implementations;
using bsg_crud_app.Repositories.Interfaces;
using bsg_crud_app.Services.Implementations;
using bsg_crud_app.Services.Interfaces;

namespace bsg_crud_app.Config;

/// <summary>
/// Program.cs extension for configure life cycle injection dependencies
/// </summary>
public static class DependenciesConfig
{
    /// <summary>
    /// Configure life cycle interfaces and implementations
    /// </summary>
    /// <param name="services"></param>
    public static void AddDependenciesLifeCycle(this IServiceCollection services)
    {
        services
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IProductService, ProductService>();
    }
}