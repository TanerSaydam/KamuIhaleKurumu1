using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services;

public interface IJwtProvider
{
    Task<LoginResponseDto> CreateTokenAsync(User user, List<Role> roles, CancellationToken cancellationToken);
}






