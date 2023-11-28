using AutoMapper;
using CleanArchitectureApp.Application.Services;
using CleanArchitectureApp.Domain.DTOs;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Domain.Repositories;
using MediatR;

namespace CleanArchitectureApp.Application.Features.TeacherFeatures.Commands.CreateTeacher;

internal sealed class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, ResponseDto>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEmployeeWithEmployeeTypeRepository _employeeWithEmployeeTypeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateTeacherCommandHandler(IEmployeeRepository employeeRepository, IEmployeeWithEmployeeTypeRepository employeeWithEmployeeTypeRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _employeeWithEmployeeTypeRepository = employeeWithEmployeeTypeRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseDto> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        var isIdentityNumberValid = GenericService.IsTcKimlikValid(request.IdentityNumber);
        if (!isIdentityNumberValid)
        {
            throw new ArgumentException("Geçersiz bir T.C. numarası girdiniz!");
        }

        Employee employee = await _employeeRepository.GetOneByExpressionAsync(p => p.IdentityNumber == request.IdentityNumber);

        if (employee is not null)
        {
            throw new ArgumentException("Bu T.C. numarası  daha önce kaydedilmiş!");
        }

        employee = _mapper.Map<Employee>(request);

        EmployeeWithEmployeeType employeeWithEmployeeType = new()
        {
            EmployeeId = employee.Id,
            EmployeeType = Domain.Enums.EmployeeType.Teacher
        };

        await _employeeRepository.AddAsync(employee, cancellationToken);
        await _employeeWithEmployeeTypeRepository.AddAsync(employeeWithEmployeeType, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new("Öğretmen kaydı başarıyla tamamlandı");
    }
}