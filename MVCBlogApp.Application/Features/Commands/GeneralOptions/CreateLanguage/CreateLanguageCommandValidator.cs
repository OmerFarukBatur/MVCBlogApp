using FluentValidation;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.CreateLanguage
{
    public class CreateLanguageCommandValidator : AbstractValidator<VM_Language>
    {
        public CreateLanguageCommandValidator() 
        {
            RuleFor(x => x.Language)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir veri giriniz")
                .MaximumLength(150)
                .MinimumLength(5)
                .WithMessage("Lütfen veriyi en az 5 karakter en çok 150 karakter olacak şekilde giriniz.");
        }
    }
}
