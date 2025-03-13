using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace bsg_crud_app.Api.Models;

/// <summary>
/// Class to convert httpStatusCode to int
/// </summary>
public class ObjectResponse : ObjectResult
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="httpStatusCode"></param>
    /// <param name="value"></param>
    public ObjectResponse(HttpStatusCode httpStatusCode, object? value) : base(value)
    {
        StatusCode = (int)httpStatusCode;
    }
}