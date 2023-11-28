using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.ProductFeature.Queries.GetAllProductWithElasticSearch;

public sealed record GetAllProductWithElasticSearchQuery(
    string Search): IRequest<List<Product>>;
