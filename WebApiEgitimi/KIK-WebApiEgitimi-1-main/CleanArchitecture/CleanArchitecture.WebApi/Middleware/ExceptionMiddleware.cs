using CleanArchitecture.Domain.Exceptions;
using System.Text.Json;

namespace CleanArchitecture.WebApi.Middleware;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            switch (ex)
            {
                case AlreadyExistException:
                    context.Response.StatusCode = 400;
                    break;
                default:
                    context.Response.StatusCode = 500;
                    break;
            }

            var response = new { Message = ex.Message };
            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);

        }
    }
}
