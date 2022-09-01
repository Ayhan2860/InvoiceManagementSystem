using Core.Entities.Concrete;
using Entities.ComplexTypes;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LoginValidator:AbstractValidator<UserForLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("Email boş olamaz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz");
            RuleFor(x => x.Password).NotNull().WithMessage("Parola boş bırakılamaz")
            .MinimumLength(5).WithMessage("Parolanız minimum beş karakter olmalıdır.");
        }
    }
}