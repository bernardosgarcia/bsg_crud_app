using System.Net;

namespace bsg_crud_app.Dtos;

public class GenericResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public GenericResponse(HttpStatusCode statusCode, T data, string message = "Successfully response")
    {
        Success = true;
        Message = message;
        Data = data;
        Errors = null;
        StatusCode = statusCode;
    }

    public GenericResponse(HttpStatusCode statusCode, List<string> errors, string message = "An error occurred")
    {
        Success = false;
        Message = message;
        Data = default;
        Errors = errors;
        StatusCode = statusCode;
    }
}