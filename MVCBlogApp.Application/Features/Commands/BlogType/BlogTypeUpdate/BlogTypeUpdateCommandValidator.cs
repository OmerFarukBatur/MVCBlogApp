using FluentValidation;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeUpdate
{
    public class BlogTypeUpdateCommandValidator : AbstractValidator<VM_BlogType>
    {
        public BlogTypeUpdateCommandValidator()
        {
            RuleFor(x => x.TypeName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen alanı baoş geçmeyiniz.")
                .MaximumLength(300)
                .MinimumLength(3)
                .WithMessage("Lütfen girilen degeri enaz 3 ve encok 300 karakter olacak şekilde giriniz.");
        }
    }
}
