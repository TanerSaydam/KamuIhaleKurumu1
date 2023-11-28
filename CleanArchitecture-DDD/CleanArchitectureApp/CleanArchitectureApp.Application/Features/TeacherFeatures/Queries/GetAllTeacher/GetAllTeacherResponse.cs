namespace CleanArchitectureApp.Application.Features.TeacherFeatures.Queries.GetAllTeacher;
public sealed record GetAllTeacherResponse(
    string Id,
    string Name,
    string Lastname,
    string PhoneNumber);