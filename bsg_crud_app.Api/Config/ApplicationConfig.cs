namespace bsg_crud_app.Api.Config;

/// <summary>
/// Program.cs extension for application settings
/// </summary>
public static class ApplicationConfig
{
    /// <summary>
    /// Configure CORS
    /// </summary>
    /// <param name="services"></param>
    public static void AddCustomCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAny",
                policy => policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }
}