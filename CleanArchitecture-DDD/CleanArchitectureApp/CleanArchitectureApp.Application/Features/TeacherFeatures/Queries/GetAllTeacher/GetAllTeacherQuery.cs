using CleanArchitectureApp.Domain.Entities;
using MediatR;

namespace CleanArchitectureApp.Application.Features.TeacherFeatures.Queries.GetAllTeacher;
public sealed record GetAllTeacherQuery() : IRequest<List<GetAllTeacherResponse>>;