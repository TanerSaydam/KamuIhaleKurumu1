using CleanArchitectureApp.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureApp.Application.Features.TeacherFeatures.Queries.GetAllTeacher;

internal sealed class GetAllTeacherQueryHandler : IRequestHandler<GetAllTeacherQuery, List<GetAllTeacherResponse>>
{
    private readonly IEmployeeWithEmployeeTypeRepository _employeeWithEmployeeTypeRepository;

    public GetAllTeacherQueryHandler(IEmployeeWithEmployeeTypeRepository employeeWithEmployeeTypeRepository)
    {
        _employeeWithEmployeeTypeRepository = employeeWithEmployeeTypeRepository;
    }

    public async Task<List<GetAllTeacherResponse>> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
    {
        List<GetAllTeacherResponse> response =
            await _employeeWithEmployeeTypeRepository
            .GetWhere(p => p.EmployeeType == Domain.Enums.EmployeeType.Teacher)
            .Include(i => i.Employee)
            .Select(s => new GetAllTeacherResponse(
                    s.Employee.Id.ToString(),
                    s.Employee.Name,
                    s.Employee.Lastname,
                    s.Employee.PhoneNumber))
            .ToListAsync(cancellationToken);

        return response;
    }
}