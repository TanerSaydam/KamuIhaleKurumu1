using FluentValidation;
using KIKWebApi.DTOs;

namespace KIKWebApi.Validators;

public sealed class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(p=> p.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
        RuleFor(p=> p.UserName).NotNull().WithMessage("Kullanıcı adı boş olamaz");
        RuleFor(p=> p.Email).NotEmpty().WithMessage("Email adres boş olamaz");
        RuleFor(p=> p.Email).NotNull().WithMessage("Email adres boş olamaz");
        RuleFor(p=> p.Password).NotEmpty().WithMessage("Şifre adres boş olamaz");
        RuleFor(p=> p.Password).NotNull().WithMessage("Şifre adres boş olamaz");
        RuleFor(p=> p.NameLastName).NotEmpty().WithMessage("Ad ve soyad boş olamaz");
        RuleFor(p=> p.NameLastName).NotNull().WithMessage("Ad ve soyad boş olamaz");
        RuleFor(p => p.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifreniz en az 1 adet büyük harf içermelidir");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifreniz en az 1 adet küçük harf içermelidir");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifreniz en az 1 adet sayı içermelidir");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az 1 adet özel karakter içermelidir");
    }
}
