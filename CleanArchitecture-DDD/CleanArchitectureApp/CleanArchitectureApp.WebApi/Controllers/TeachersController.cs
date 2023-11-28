using CleanArchitectureApp.Application.Features.TeacherFeatures.Commands.CreateTeacher;
using CleanArchitectureApp.Application.Features.TeacherFeatures.Queries.GetAllTeacher;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApp.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public sealed class TeachersController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeachersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeacher(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> GetTeachers(GetAllTeacherQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}