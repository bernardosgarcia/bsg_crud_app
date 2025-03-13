/*using System.Net;
using System.Text.Json;
using bsg_crud_app.Exceptions;

namespace bsg_crud_app.Application.Exceptions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
        catch (DbUpdateException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        const HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        var response = new
        {
            message = "An unexpected error occurred",
            detail = exception.Message
        };

        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static Task HandleExceptionAsync(HttpContext context, NotFoundException exception)
    {
        const HttpStatusCode statusCode = HttpStatusCode.NotFound;
        var response = new
        {
            message = "Resource not found.",
            detail = exception.Message
        };

        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static Task HandleExceptionAsync(HttpContext context, DbUpdateException exception)
    {
        const HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        var response = new
        {
            message = "An error occurred while saving changes to the database.",
            detail = exception.InnerException?.Message
        };

        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

} */