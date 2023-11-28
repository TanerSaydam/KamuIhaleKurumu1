namespace OnConfigurationVsDbContextOptions.IoC;

public static class ServiceTool
{
    public static IServiceProvider ServiceProvider { get; private set; }
    public static IServiceCollection CreateProvider(this IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
        return services;
    }
}
