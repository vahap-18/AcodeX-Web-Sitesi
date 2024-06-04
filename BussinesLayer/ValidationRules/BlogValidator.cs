using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            //Blog hakkındaki kuralların yer aldığı sayfadır

            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog başlığını boş geçemezsiniz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Blog açıklamasını boş geçemezsiniz.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Blog içeriğini boş geçemezsiniz.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Blog görselini boş geçemezsiniz.");
            RuleFor(x => x.Title).MaximumLength(250).WithMessage("Blog başlığı maximum 250 karakter olabilir");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Blog açıklaması minimum 10 karakter olabilir");
        }
    }
}
