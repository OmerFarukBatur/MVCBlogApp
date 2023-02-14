using FluentValidation;

namespace MVCBlogApp.Application.Features.Queries.Home.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQueryRequest>
    {
        public LoginQueryValidator()
        {
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
                    .MinimumLength(6);
        }
    }
}
