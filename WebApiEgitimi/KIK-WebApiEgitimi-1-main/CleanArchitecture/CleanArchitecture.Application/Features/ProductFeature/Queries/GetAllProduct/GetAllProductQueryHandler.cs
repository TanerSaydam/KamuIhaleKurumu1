using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;

namespace CleanArchitecture.Application.Features.ProductFeature.Queries.GetAllProduct;

internal sealed class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, PaginationResult<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<PaginationResult<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var response = await _productRepository
            .GetWhere(p => p.Name.ToLower().Contains(request.Search.ToLower()))
            .ToPagedListAsync(request.PageNumber, request.PageSize);
        return response;
    }
}
