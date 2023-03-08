using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserUpdate
{
    public class UserUpdateCommandValidator : AbstractValidator<UserUpdateCommandRequest>
    {
        public UserUpdateCommandValidator() 
        {
            RuleFor(x => x.NameSurname)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Ad'ı boş geçmeyiniz.")
                .MaximumLength(200)
                .MinimumLength(2)
                .WithMessage("Lütfen Adı ve Soyadınızı minimum 2 karakter maksimum 200 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Email'i boş geçmeyiniz.")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir email adresi giriniz.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Telefon Numarası'nı boş geçmeyiniz.")
                .MaximumLength(25)
                .WithMessage("Lütfen Telefon Numarasını maksimum 25 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Password)
                .MinimumLength(6)
                .WithMessage("Lütfen şifrenizi enaz 6 karakter olacak şekilde giriniz.");

            RuleFor(x => x.PasswordConfirm)
                .Equal(s => s.Password)
                .WithMessage("Şifreler Uyuşmuyor.");

            RuleFor(x => x.Lacation)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Şehir bölümünü boş bırakmayınız.")
                .MaximumLength(100)
                .MinimumLength(2)
                .WithMessage("Lütfen Şehiri minimum 2 karakter maksimum 100 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Address)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Adres bölümünü boş bırakmayınız.")
                .MaximumLength(300)
                .MinimumLength(2)
                .WithMessage("Lütfen Adres minimum 2 karakter maksimum 100 karakter olacak şekilde giriniz.");

            RuleFor(x => x.MembersAuthId)
               .NotNull()
               .WithMessage("Lütfen bir Yetki şeçiniz.");

            RuleFor(x => x.IsActive)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");
        }
    }
}
