namespace KIKWebApi.Authorization;

public sealed record LoginDto(
    string Token,
    string RefreshToken,
    DateTime RefreshTokenExpires);