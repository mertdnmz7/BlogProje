using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator: AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar adı boş geçilemez.");
            RuleFor(x => x.AboutShort).NotEmpty().WithMessage("Yazar yetenekleri giriniz");
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail adresi girilmesi zorunludur.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Zorunludur.");
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Yazar hakkında kısmı boş bırakılamaz.");

        }
    }
}
