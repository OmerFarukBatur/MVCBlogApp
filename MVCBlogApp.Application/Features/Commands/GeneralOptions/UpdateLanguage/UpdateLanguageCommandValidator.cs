using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.UpdateLanguage
{
    public class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommandRequest>
    {
        public UpdateLanguageCommandValidator() 
        {
            RuleFor(x => x.Language)
                .MaximumLength(150)
                .MinimumLength(5)
                .WithMessage("Lütfen veriyi en az 5 karakter en çok 150 karakter olacak şekilde giriniz.");
        }
    }
}
