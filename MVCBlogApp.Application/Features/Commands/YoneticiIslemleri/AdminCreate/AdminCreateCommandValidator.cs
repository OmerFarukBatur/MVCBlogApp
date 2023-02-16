using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminCreate
{
    public class AdminCreateCommandValidator : AbstractValidator<AdminCreateCommandRequest>
    {
        public AdminCreateCommandValidator() 
        {
            RuleFor(a => a.UserName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen isim alanını boş geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(5)
                .WithMessage("Lütfen UserName'i enaz 5 en çok 150 karakter olacak şekilde giriniz");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Email'i boş geçmeyiniz.")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir email adresi giriniz.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Şifre'yi boş geçmeyiniz.")
                .MinimumLength(6)
                .WithMessage("Lütfen şifrenizi enaz 6 karakter olacak şekilde giriniz.");

            RuleFor(x => x.PasswordConfirm)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Şifre'yi boş geçmeyiniz.")
                .Equal(s => s.Password)
                .WithMessage("Şifreler Uyuşmuyor.");

            RuleFor(x => x.AuthID) 
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir Rol şeçiniz.");
        }
    }
}
