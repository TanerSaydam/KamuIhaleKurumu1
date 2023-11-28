using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeature.Login;

public sealed record LoginCommand(
    string UserName): IRequest<LoginResponseDto>;
