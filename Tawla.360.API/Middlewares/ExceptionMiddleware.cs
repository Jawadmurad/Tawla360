using System.Text.Json;
using Tawla._360.Domain.Exceptions;


namespace Tawla._360.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        Stream originalBodyStream = context.Response.Body;

        try
        {
            // Only buffer the response if we might need to handle an exception
            await using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context);

            // If no exception occurred, copy the buffered response to the original stream
            responseBody.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);
        }
        catch (BadRequestException ex)
        {
            // Restore the original stream before handling the exception
            context.Response.Body = originalBodyStream;
            await HandleException(context, StatusCodes.Status400BadRequest, ex.Message, ex);
        }
        catch (Exception ex)
        {
            // Restore the original stream before handling the exception
            context.Response.Body = originalBodyStream;
            _logger.LogError(ex, "An unhandled exception occurred");
            var message= ex.Message;
            if (ex.InnerException != null)
            {
                message+=Environment.NewLine;
                message+=ex.InnerException.Message;
            }
            await HandleException(context, StatusCodes.Status500InternalServerError, message, ex);
        }
    }

    private async Task HandleException(HttpContext context, int statusCode, string message, Exception ex)
    {
        try
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            var errorPayload = new { Error = message };
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorPayload));
        }
        catch (Exception ex2)
        {
            _logger.LogError(ex, "original exception");
            _logger.LogError(ex2, "Failed to write error response");
        }
    }
}
