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
        try
        {
            var originalBodyStream = context.Response.Body;
            await using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;
            await _next(context);
        }
        catch (BadRequestException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
            var response = new
            {
                error = ex.Message
            };
            try
            {
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            catch (Exception xx)
            {
                System.Console.WriteLine(xx.Message);
            }
            // // Serialize to JSON and write to response
            // await context.Response.WriteAsJsonAsync(response);
        }
    }
    private async Task HandleException(HttpContext context, int statusCode, string message, Exception ex)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";
        var errorPayload = new { Error = message };
        await context.Response.WriteAsync(JsonSerializer.Serialize(errorPayload));
    }
}
