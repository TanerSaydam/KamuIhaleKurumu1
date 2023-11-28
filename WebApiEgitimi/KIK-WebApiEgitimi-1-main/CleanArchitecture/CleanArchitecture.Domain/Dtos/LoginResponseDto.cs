namespace CleanArchitecture.Domain.Dtos;

public sealed record LoginResponseDto(
string Token,
Guid UserId);
