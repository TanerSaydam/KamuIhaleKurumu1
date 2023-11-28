using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Domain.Repositories;
using CleanArchitectureApp.Infrastructure.Context;

namespace CleanArchitectureApp.Infrastructure.Repositories;

internal sealed class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }
}