using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(X => X.Email).NotEmpty().WithMessage("E-Mail adresi boş geçilemez");
            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Parola boş olamaz.") // Parolanın boş olmamasını sağlar
            .MinimumLength(6).WithMessage("Parola en az 6 karakterden oluşmalıdır.") // Parolanın en az 6 karakter olmasını sağlar
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$")
                .WithMessage("Parola en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.");
            // Parolanın en az bir büyük harf, bir küçük harf ve bir rakam içermesini sağlar
        }
    }
}
