using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules
{
    public class LoginValidator : AbstractValidator<Writer>
    {
        public LoginValidator() {
            RuleFor(X => X.Email).NotEmpty().WithMessage("E-Mail adresi boş geçilemez").EmailAddress().WithMessage("Geçerli bir E-Mail adresi giriniz"); ;
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş olamaz.").MinimumLength(6).WithMessage("Parola en az 6 karakterden oluşmalıdır.").Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$").WithMessage("Parola en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.");
        }
    }
}
