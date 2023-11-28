using AutoMapper;
using CleanArchitectureApp.Application.Features.TeacherFeatures.Commands.CreateTeacher;
using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Application.Mapping;

internal sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateTeacherCommand, Employee>();
    }
}