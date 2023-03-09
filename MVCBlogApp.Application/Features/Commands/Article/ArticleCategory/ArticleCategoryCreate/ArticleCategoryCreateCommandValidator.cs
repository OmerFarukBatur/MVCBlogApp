using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryCreate
{
    public class ArticleCategoryCreateCommandValidator : AbstractValidator<ArticleCategoryCreateCommandRequest>
    {
        public ArticleCategoryCreateCommandValidator() 
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Kategori Adını boş geçmeyiniz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Kategori Adını minimum 2 karakter maksimum 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.MetaTitle)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen MetaTitle boş geçmeyiniz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen MetaTitle minimum 2 karakter maksimum 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.MetaKey)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen MetaKey boş geçmeyiniz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen MetaKey minimum 2 karakter maksimum 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.MetaDescription)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen MetaDescription boş geçmeyiniz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen MetaDescription minimum 2 karakter maksimum 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.LangId)
               .NotNull()
               .WithMessage("Lütfen bir Dil şeçiniz.");

            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");
        }
    }
}
