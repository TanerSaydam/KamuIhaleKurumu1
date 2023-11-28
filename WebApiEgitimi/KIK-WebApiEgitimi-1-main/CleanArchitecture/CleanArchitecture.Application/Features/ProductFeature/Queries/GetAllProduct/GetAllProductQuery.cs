using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;

namespace CleanArchitecture.Application.Features.ProductFeature.Queries.GetAllProduct;

public sealed record GetAllProductQuery(
    int PageNumber,
    int PageSize,
    string Search) : IRequest<PaginationResult<Product>>;

