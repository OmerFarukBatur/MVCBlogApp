using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminUpdate
{
    public class AdminUpdateCommandValidator : AbstractValidator<AdminUpdateCommandRequest>
    {
        public AdminUpdateCommandValidator() 
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
                .MinimumLength(6)
                .WithMessage("Lütfen şifrenizi enaz 6 karakter olacak şekilde giriniz.");

            RuleFor(x => x.PasswordConfirm)
                .Equal(s => s.Password)
                .WithMessage("Şifreler Uyuşmuyor.");

            RuleFor(x => x.IsActive)
                .NotNull()
                .WithMessage("Lütfen bir Rol şeçiniz.");
        }
    }
}
