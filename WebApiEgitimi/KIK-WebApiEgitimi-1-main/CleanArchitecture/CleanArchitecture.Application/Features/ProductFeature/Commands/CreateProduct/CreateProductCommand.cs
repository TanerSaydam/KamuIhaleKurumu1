using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.ProductFeature.Commands.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    decimal Price): IRequest<ResponseDto>;

  

