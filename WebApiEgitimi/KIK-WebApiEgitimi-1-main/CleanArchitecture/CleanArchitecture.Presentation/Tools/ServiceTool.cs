using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Presentation.Tools;

public static class ServiceTool
{
    public static IServiceProvider ServiceProvider { get; set; }
    public static IServiceCollection GetService(this IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
        return services;
    }
}
