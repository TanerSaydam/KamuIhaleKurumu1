using FluentValidation;

namespace CleanArchitectureApp.Application.Features.TeacherFeatures.Commands.CreateTeacher;

internal sealed class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
{
    public CreateTeacherCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Geçerli bir ad giriniz");
        RuleFor(p => p.Name).NotNull().WithMessage("Geçerli bir ad giriniz");
        RuleFor(p => p.Name).MinimumLength(3).WithMessage("Geçerli bir ad giriniz");
        RuleFor(p => p.Lastname).NotEmpty().WithMessage("Geçerli bir soyad giriniz");
        RuleFor(p => p.Lastname).NotNull().WithMessage("Geçerli bir soyad giriniz");
        RuleFor(p => p.Lastname).MinimumLength(3).WithMessage("Geçerli bir soyad giriniz");
        RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir email giriniz");
        RuleFor(p => p.Email).NotEmpty().WithMessage("Geçerli bir email giriniz");
        RuleFor(p => p.Email).NotNull().WithMessage("Geçerli bir email giriniz");
        RuleFor(p => p.PhoneNumber).NotNull().WithMessage("Geçerli bir telefon numarası giriniz");
        RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("Geçerli bir telefon numarası giriniz");
        RuleFor(p => p.PhoneNumber).MinimumLength(10).WithMessage("Geçerli bir telefon numarası giriniz");
        RuleFor(p => p.FullAddress).EmailAddress().WithMessage("Geçerli bir tam adres giriniz");
        RuleFor(p => p.FullAddress).NotEmpty().WithMessage("Geçerli bir tam adres giriniz");
        RuleFor(p => p.FullAddress).MinimumLength(10).WithMessage("Geçerli bir tam adres giriniz");
        RuleFor(p => p.IdentityNumber).MinimumLength(11).WithMessage("Geçerli bir T.C. Nuarası giriniz");
        RuleFor(p => p.IdentityNumber).MaximumLength(11).WithMessage("Geçerli bir T.C. Nuarası giriniz");
    }
}