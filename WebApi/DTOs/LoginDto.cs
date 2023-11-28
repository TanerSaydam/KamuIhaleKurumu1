namespace KIKWebApi.DTOs;

public sealed record LoginDto(
    string UserNameOrEmail,
    string Password);
