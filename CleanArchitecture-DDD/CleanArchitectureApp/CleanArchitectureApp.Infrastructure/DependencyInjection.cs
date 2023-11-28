using CleanArchitectureApp.Domain.Repositories;
using CleanArchitectureApp.Infrastructure.Context;
using CleanArchitectureApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        //dependency injection için otomatik eşleştirme sağlıyor
        services.Scan(selector => selector
        .FromAssemblies(Assembly.GetExecutingAssembly())
        .AddClasses(publicOnly: false)
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsMatchingInterface()
        .WithScopedLifetime());

        //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        //services.AddScoped<IEmployeeWithEmployeeTypeRepository, EmployeeWithEmployeeTypeRepository>();

        return services;
    }
}