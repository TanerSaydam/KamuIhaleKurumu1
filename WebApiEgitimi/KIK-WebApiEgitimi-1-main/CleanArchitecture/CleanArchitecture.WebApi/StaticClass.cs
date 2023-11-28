using CleanArchitecture.WebApi.Tools;

namespace CleanArchitecture.WebApi;

public static class StaticClass
{
    public static void GetContextInformation()
    {
       var context = ServiceTool.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
        var result = context.HttpContext.User.Claims.ToList();
    }
}
