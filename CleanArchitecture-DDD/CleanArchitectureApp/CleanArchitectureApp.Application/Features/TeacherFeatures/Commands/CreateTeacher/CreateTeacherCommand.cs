using CleanArchitectureApp.Domain.DTOs;
using MediatR;

namespace CleanArchitectureApp.Application.Features.TeacherFeatures.Commands.CreateTeacher;
public sealed record CreateTeacherCommand(
    string Name,
    string Lastname,
    string Email,
    string PhoneNumber,
    string IdentityNumber,
    DateTime DateOfBirth,
    string City,
    string Town,
    string FullAddress) : IRequest<ResponseDto>;