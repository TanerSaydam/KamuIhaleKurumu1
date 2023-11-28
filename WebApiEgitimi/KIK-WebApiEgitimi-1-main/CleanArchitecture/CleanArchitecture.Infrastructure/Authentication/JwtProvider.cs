using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.Infrastructure.Authentication;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _jwtOptions;

    public JwtProvider(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<LoginResponseDto> CreateTokenAsync(User user, List<Role> roles, CancellationToken cancellationToken)
    {
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier,user.UserName),
            new Claim("UserId",user.Id.ToString()),
            new Claim(ClaimTypes.Role,JsonConvert.SerializeObject(roles.Select(r=> new
            {
                Role = r.Name
            })))
        };

        DateTime expires = DateTime.Now.AddSeconds(10);

        JwtSecurityToken jwtSecurityToken = new(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), SecurityAlgorithms.HmacSha256));

        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return new(token, user.Id);
    }
}
