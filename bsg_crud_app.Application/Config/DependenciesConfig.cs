using bsg_crud_app.Application.Services.Implementations;
using bsg_crud_app.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace bsg_crud_app.Application.Config;

/// <summary>
/// Program.cs extension for configure life cycle injection dependencies
/// </summary>
public static class DependenciesConfig
{
    /// <summary>
    /// Configure life cycle interfaces and implementations
    /// </summary>
    /// <param name="services"></param>
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }

}