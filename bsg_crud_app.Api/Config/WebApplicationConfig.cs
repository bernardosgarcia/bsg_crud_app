//using ExceptionMiddleware = bsg_crud_app.Application.Exceptions.ExceptionMiddleware;

namespace bsg_crud_app.Api.Config;

/// <summary>
/// Program.cs extension for configure web application configs and middlewares
/// </summary>
public static class WebApplicationConfig
{
    /// <summary>
    /// Configure web application and middlewares
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static void ConfigureWebApplication(this WebApplication app)
    {
        //Configured CORS on ServiceConfig.cs
        app.UseCors("AllowAny");

        //app.UseMiddleware<ExceptionMiddleware>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
            });
        }

        app.UseHttpsRedirection();
        app.MapControllers();
    }
}