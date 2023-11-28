using FluentValidation;
using KIKWebApi.Authentincation;
using KIKWebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using User = KIKWebApi.Models.User;

namespace KIKWebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IValidator<RegisterDto> _validator;
    private readonly IValidator<LoginDto> _loginValidator;

    public AuthController(IValidator<RegisterDto> validator, IValidator<LoginDto> loginValidator)
    {
        _validator = validator;
        _loginValidator = loginValidator;
    }

    [HttpPost]
    public IActionResult Register(RegisterDto request)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            return StatusCode(403, validationResult.Errors);
        }

        User user = Constants.Users.FirstOrDefault(p => p.UserName == request.UserName);
        if (user != null) throw new Exception("Bu kullanıcı adı daha önce kullanılmış!");

        user = Constants.Users.FirstOrDefault(p => p.Email == request.Email);
        if (user != null) throw new Exception("Bu email adresi daha önce kullanılmış!");

        user = new()
        {
            Email = request.Email,
            UserName = request.UserName,
            NameLastName = request.NameLastName,
            Password = request.Password,
        };

        Constants.Users.Add(user);  

        return Ok(new { Message = "Kayıt işlemi başarıyla tamamlandı" });
    }

    [HttpPost]
    public IActionResult Login(LoginDto request)
    {
        var validationResult = _loginValidator.Validate(request);

        if (!validationResult.IsValid)
        {
            return StatusCode(403, validationResult.Errors);
        }

        User user = Constants.Users.FirstOrDefault(p => p.UserName == request.UserNameOrEmail || p.Email == request.UserNameOrEmail);
        if (user == null) throw new Exception("Kullanıcı bulunamadı");

        if(user.Password != request.Password) throw new Exception("Şifre doğru değil");

        List<string> roles = Constants.UserRoles.Where(p=> p.UserId == user.Id).Select(s=> s.RoleName).ToList();

        var response = JwtProvider.CreateToken(user, roles);
        return Ok(response);
    }

    [HttpPost("{refreshToken}")]
    public IActionResult LoginWithRefreshToken(string refreshToken)
    {
        User user = Constants.Users.FirstOrDefault(p=> p.RefreshToken == refreshToken);
        if (user == null) throw new Exception("Kullanıcı bulunamadı");
        if (user.RefreshTokenExpires < DateTime.Now) throw new Exception("Refresh token süresi dolmuş!");
        
        List<string> roles = Constants.UserRoles.Where(p => p.UserId == user.Id).Select(s => s.RoleName).ToList();

        var response = JwtProvider.CreateToken(user, roles);
        return Ok(response);
    }
}


