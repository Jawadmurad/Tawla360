using System;
using System.Text;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Tawla._360.Logging.Middlewares;

public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestResponseLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Log request
        var request = await FormatRequest(context.Request);
        Log.Information("HTTP Request {Method} {Path} {Body}", context.Request.Method, context.Request.Path, request);

        // Copy original response body stream
        var originalBodyStream = context.Response.Body;

        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        await _next(context);

        // Log response
        var response = await FormatResponse(context.Response);
        Log.Information("HTTP Response {StatusCode} {Body}", context.Response.StatusCode, response);

        // Copy back to original stream
        await responseBody.CopyToAsync(originalBodyStream);
    }

    private async Task<string> FormatRequest(HttpRequest request)
    {
        request.EnableBuffering(); // Allows reading the body multiple times
        using var reader = new StreamReader(request.Body, Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true);
        var body = await reader.ReadToEndAsync();
        request.Body.Position = 0;
        return body;
    }

    private async Task<string> FormatResponse(HttpResponse response)
    {
        response.Body.Seek(0, SeekOrigin.Begin);
        var text = await new StreamReader(response.Body).ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin);
        return text;
    }
}


