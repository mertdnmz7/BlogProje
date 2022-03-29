using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Title Boş geçilemez.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog İçeriği Boş geçilemez");
            RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("Lütfen en az 3 karakterlik blog başlığı girişi yapınız.");
            RuleFor(x => x.BlogContent).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakterlik blog başlığı girişi yapınız.");
        }
    }
}
