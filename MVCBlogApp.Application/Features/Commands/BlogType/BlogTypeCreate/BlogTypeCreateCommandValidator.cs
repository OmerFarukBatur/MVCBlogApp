using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeCreate
{
    public class BlogTypeCreateCommandValidator : AbstractValidator<BlogTypeCreateCommandRequest>
    {
        public BlogTypeCreateCommandValidator()
        {
            RuleFor(x => x.TypeName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen alanı baoş geçmeyiniz.")
                .MaximumLength(300)
                .MinimumLength(3)
                .WithMessage("Lütfen girilen degeri enaz 3 ve encok 300 karakter olacak şekilde giriniz.");

            RuleFor(x => x.LangId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Dil şeçiniz.");
        }
    }
}
