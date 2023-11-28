using CleanArchitecture.Presentation.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Presentation;

public static class StaticClass
{
    public static void GetContextInformation()
    {
       var context = ServiceTool.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
        var result = context.HttpContext.User.Claims.ToList();
    }
}
