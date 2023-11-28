using FluentValidation;
using KIKWebApi.DTOs;
using KIKWebApi.Models;

namespace KIKWebApi.Validators;

public sealed class PersonelValidator : AbstractValidator<CreatePersonelDto>
{
    public PersonelValidator()
    {
        RuleFor(p=> p.Name).NotEmpty().WithMessage("Personel adı boş olamaz");
        RuleFor(p=> p.Name).NotNull().WithMessage("Personel adı boş olamaz");
        RuleFor(p=> p.LastName).NotEmpty().WithMessage("Personel soyadı boş olamaz");
        RuleFor(p=> p.LastName).NotNull().WithMessage("Personel soyadı boş olamaz");
        RuleFor(p=> p.Profession).NotEmpty().WithMessage("Meslek bilgisi boş olamaz");
        RuleFor(p=> p.Profession).NotNull().WithMessage("Meslek bilgisi boş olamaz");
        RuleFor(p=> p.StartingDate).NotNull().WithMessage("İşe giriş tarihi boş olamaz");
        RuleFor(p=> p.StartingDate).NotEmpty().WithMessage("İşe giriş tarihi boş olamaz");
    }
}
