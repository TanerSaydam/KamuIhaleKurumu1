using CleanArchitecture.Application.Features.ProductFeature.Commands.CreateProduct;
using CleanArchitecture.Application.Features.ProductFeature.Commands.SyncElasticProduct;
using CleanArchitecture.Application.Features.ProductFeature.Queries.GetAllProduct;
using CleanArchitecture.Application.Features.ProductFeature.Queries.GetAllProductWithElasticSearch;
using CleanArchitecture.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controller;

public sealed class ProductsController : ApiController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> SnycElastic(SyncElasticProductCommand request , CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request,cancellationToken);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> GetAllWithElasticSearch(GetAllProductWithElasticSearchQuery request , CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request,cancellationToken);
        return Ok(response);
    }
}
