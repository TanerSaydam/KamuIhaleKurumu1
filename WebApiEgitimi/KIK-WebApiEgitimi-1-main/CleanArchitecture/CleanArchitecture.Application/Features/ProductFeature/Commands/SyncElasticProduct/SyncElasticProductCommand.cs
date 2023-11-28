using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.ProductFeature.Commands.SyncElasticProduct;

public sealed record SyncElasticProductCommand(): IRequest<ResponseDto>;
