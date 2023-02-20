using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Home.PasswordReset
{
    public class PasswordResetCommandValidator : AbstractValidator<PasswordResetCommandRequest>
    {
        public PasswordResetCommandValidator()
        {
            RuleFor(a => a.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir email adresi giriniz.")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir email giriniz.");
        }
    }
}
