using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Domain.Repositories;
using CleanArchitectureApp.Infrastructure.Context;

namespace CleanArchitectureApp.Infrastructure.Repositories;

internal sealed class EmployeeWithEmployeeTypeRepository : Repository<EmployeeWithEmployeeType>, IEmployeeWithEmployeeTypeRepository
{
    public EmployeeWithEmployeeTypeRepository(ApplicationDbContext context) : base(context)
    {
    }
}