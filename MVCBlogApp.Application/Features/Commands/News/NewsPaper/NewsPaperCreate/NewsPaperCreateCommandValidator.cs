using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.News.NewsPaper.NewsPaperCreate
{
    public class NewsPaperCreateCommandValidator : AbstractValidator<NewsPaperCreateCommandRequest>
    {
        public NewsPaperCreateCommandValidator()
        {
            RuleFor(x => x.NewsPaperName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Gazete adı alanını boş geçmeyiniz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Gazete adını enaz 2 ençok ise 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.LangId)
               .NotNull()
               .WithMessage("Lütfen bir Dil şeçiniz.");
        }
    }
}
