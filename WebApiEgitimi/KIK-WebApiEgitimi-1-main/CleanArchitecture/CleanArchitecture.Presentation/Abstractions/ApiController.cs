using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Abstractions;

[ApiController]
[Route("api/[controller]/[action]")]
//[Authorize(AuthenticationSchemes ="Bearer")]
public abstract class ApiController : ControllerBase
{
    internal readonly IMediator _mediator;

    protected ApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
