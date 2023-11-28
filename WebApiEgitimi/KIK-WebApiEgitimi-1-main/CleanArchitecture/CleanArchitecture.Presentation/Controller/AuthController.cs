using CleanArchitecture.Application.Features.AuthFeature.Login;
using CleanArchitecture.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CleanArchitecture.Presentation.Controller;

public sealed class AuthController : ApiController
{
    private readonly IHttpContextAccessor _contextAccessor;
    public AuthController(IMediator mediator, IHttpContextAccessor contextAccessor) : base(mediator)
    {
        _contextAccessor = contextAccessor;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetContext()
    {
        //var result = _contextAccessor.HttpContext.User.Claims.ToList();
        StaticClass.GetContextInformation();
        return Ok();
    }
}



