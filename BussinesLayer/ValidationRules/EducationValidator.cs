using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules
{
    public class EducationValidator : AbstractValidator<Education>
    {
       public EducationValidator() {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlığı boş geçemezsiniz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklamayı boş geçemezsiniz.");
            RuleFor(x => x.ContentText).NotEmpty().WithMessage("İçerik metnini boş geçemezsiniz.");
            RuleFor(x => x.Requirement).NotEmpty().WithMessage("Gereksinimleri boş geçemezsiniz.");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Kategori belirtmelisiniz");
        }
    }
}
