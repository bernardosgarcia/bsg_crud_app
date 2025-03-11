using System.Text.Json;
using Microsoft.OpenApi.Models;

namespace bsg_crud_app.Config;

/// <summary>
/// Program.cs extension for services configuration
/// </summary>
public static class ServiceConfig
{
    /// <summary>
    /// Configure API initialize services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        //Add controllers that expect to receive and send json with camelCase
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });
        });
        services.AddCustomCors();
        services.AddDependenciesLifeCycle();
    }
}