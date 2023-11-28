using FluentValidation;
using KIKWebApi.DTOs;

namespace KIKWebApi.Validators;

public sealed class LoginValidator: AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Geçerli kullanıcı adı ya email yazmalısınız");
        RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Geçerli kullanıcı adı ya email yazmalısınız");
        RuleFor(p=> p.Password).NotEmpty().WithMessage("Şifre boş olamaz");
        RuleFor(p=> p.Password).NotNull().WithMessage("Şifre boş olamaz");
        RuleFor(p => p.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifreniz en az 1 adet büyük harf içermelidir");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifreniz en az 1 adet küçük harf içermelidir");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifreniz en az 1 adet sayı içermelidir");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az 1 adet özel karakter içermelidir");
    }
}
