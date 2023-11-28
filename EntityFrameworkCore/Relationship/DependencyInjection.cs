using Microsoft.EntityFrameworkCore;
using Relationship.Context;

namespace Relationship;

public static class DependencyInjection
{
    private const string SqlServer = nameof(SqlServer);
    public static IServiceCollection CreateDatabase(
        this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(opt=> 
            opt.UseSqlServer(
                services
                .BuildServiceProvider()
                .GetRequiredService<IConfiguration>()
                .GetConnectionString(SqlServer)));
        return services;
    }
}
