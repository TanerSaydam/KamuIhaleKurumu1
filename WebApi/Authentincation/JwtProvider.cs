using KIKWebApi.Authorization;
using KIKWebApi.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KIKWebApi.Authentincation;

public static class JwtProvider
{
    public static LoginDto CreateToken(User user, List<string> roles)
    {
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.NameLastName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, JsonConvert.SerializeObject(roles))
        };

        string issuer = "Issuer";
        string audience = "Audience";
        string securityKey = "my secret key my secret key my secret key";

        DateTime expires = DateTime.Now.AddMinutes(10);

        var jwtSecurity = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)), SecurityAlgorithms.HmacSha256));

        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurity);

        string refreshToken = Guid.NewGuid().ToString();
        DateTime refreshTokenExpires = expires.AddMinutes(10);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = refreshTokenExpires;

        return new(token,refreshToken,refreshTokenExpires);
    }   
}
