using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationCreate
{
    public class NavigationCreateCommandValidator : AbstractValidator<NavigationCreateCommandRequest>
    {
        public NavigationCreateCommandValidator() 
        {
            RuleFor(x => x.MetaTitle)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen MetaTitle bölümünü boş geçmeyiniz.");

            RuleFor(x => x.NavigationName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen NavigationName bölümünü boş geçmeyiniz.");

            RuleFor(x => x.IsActive)
                .NotNull()
                .WithMessage("Lütfen bir Rol şeçiniz.");

            RuleFor(x => x.LangID)
                .NotNull()
                .WithMessage("Lütfen bir Rol şeçiniz.");

            RuleFor(x => x.IsAdmin)
                .NotNull()
                .WithMessage("Lütfen bir Rol şeçiniz.");
        }
    }
}
